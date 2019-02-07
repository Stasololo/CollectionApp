using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CollectionApp.Models;
using CollectionApp.Repositories;
using CollectionApp.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CollectionApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly CashCentreRepository _cashCentreRepository;
        private ApplicationSignInManager _signInManager;

        private UserManager _userManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<UserManager>();
            }
        }

        private RoleManager _roleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<RoleManager>();
            }
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public UsersController()
        {
            _cashCentreRepository = new CashCentreRepository();
            
        }
       
        //GET: Users
        public ActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }


        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userManager.Users
                .Include("CashCentre")
                .FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //GET: Users/Create
        public ActionResult Create()
        {
            var roleList = _roleManager.Roles.ToList();
            ViewBag.RoleId = new SelectList(roleList, "Id", "Name");
            ViewBag.CashCentreId = new SelectList(_cashCentreRepository.Get(), "Id", "Name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastUpdateUser,Code,Reference,ExpireDate,RoleId,Email,PhoneNumber,Name,Password,ConfirmPassword,CashCentreId")] CreateUserVM model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Email = model.Email,
                    UserName = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Reference = model.Reference,
                    LastUpdateUser = User.Identity.Name,
                    LastUpdate = DateTime.Now,
                    CashCentreId = model.CashCentreId,
                    Creation = DateTime.Now,
                    Code = model.Code,
                    ExpireDate = model.ExpireDate
                };

                var result = _userManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    var role = _roleManager.Roles.First(x => x.Id == model.RoleId);
                    var roleName = role.Name;

                    _userManager.AddToRole(user.Id, roleName);

                    return RedirectToAction("Index");
                }
            }
            ViewBag.RoleId = new SelectList(_roleManager.Roles, "Id", "Name", model.RoleId);
            ViewBag.CashCentreId = new SelectList(_cashCentreRepository.Get(), "Id", "Name", model.CashCentreId);
            return View();
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string Id)
        {
            User user = await _userManager.FindByIdAsync(Id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Users");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> Edit(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                EditUserVM model = new EditUserVM {
                    Code = user.Code,
                    CashCentreId = user.CashCentreId,
                    ExpireDate = user.ExpireDate,
                    Reference = user.Reference,
                    Email = user.Email,
                    Name = user.UserName,
                    PhoneNumber = user.PhoneNumber

                };
                ViewBag.CashCentreId = new SelectList(_cashCentreRepository.Get(), "Id", "Name");
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditUserVM model)
        {
            User user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                user.Code = model.Code;
                user.CashCentreId = model.CashCentreId;
                user.ExpireDate = model.ExpireDate;
                user.LastUpdate = DateTime.Now;
                user.LastUpdateUser = User.Identity.Name;
                user.Reference = model.Reference;
                user.PhoneNumber = model.PhoneNumber;
                user.UserName = model.Name;
                user.Email = model.Email;
                IdentityResult result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, true, true);
                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    ModelState.AddModelError("", "Что-то пошло не так");
                }
            }
            else
            {
                ModelState.AddModelError("", "Пользователь не найден");
            }
            ViewBag.CashCentreId = new SelectList(_cashCentreRepository.Get(), "Id", "Name", model.CashCentreId);
            return View(model);
        }

        #region Change role
        [Route("ChangeRole")]
        public async Task<ActionResult> ChangeRole(string Id)
        {
            // получаем пользователя
            User user = await _userManager.FindByIdAsync(Id);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user.Id);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleVM model = new ChangeRoleVM
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }
            return View();
        }

        [Route("ChangeRole")]
        [HttpPost]
        public async Task<ActionResult> ChangeRole(string userId, string[] roles)
        {
            // получаем пользователя
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user.Id);
                // получаем все роли
                var allRoles = _roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удаленыs
                var removedRoles = userRoles.Except(roles).ToArray();

                await _userManager.AddToRolesAsync(user.Id, roles);

                await _userManager.RemoveFromRolesAsync(userId, removedRoles);

                return RedirectToAction("Index");
            }
            return View();
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _userManager.Dispose();
                _roleManager.Dispose();
                _cashCentreRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
