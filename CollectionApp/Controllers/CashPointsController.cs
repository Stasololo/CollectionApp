using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CollectionApp.Models;
using CollectionApp.Repositories;
using CollectionApp.ViewModel;

namespace CollectionApp.Controllers
{
    public class CashPointsController : Controller
    {
        private readonly CashPointRepository _cashPointRepository;
        private readonly AccountRepository _accountRepository;

        public CashPointsController()
        {
            _cashPointRepository = new CashPointRepository();
            _accountRepository = new AccountRepository();
        }

        // GET: CashPoints
        public ActionResult Index()
        {
            var cashPoints = _cashPointRepository.Get();
            var cashPointVMs = new List<CashPointVM>();
            foreach (var cashPoint in cashPoints)
            {
                var cashPointVM = new CashPointVM()
                {
                    Id = cashPoint.Id,
                    Name = cashPoint.Name,
                    Address = cashPoint.Address,
                    //SelectedAccountNamesStr = cashPoint.Accounts.Any()?cashPoint.Accounts.Select(x => x.Name).Aggregate((a, b) => a + ", " + b) : string.Empty
                };
                cashPointVMs.Add(cashPointVM);
            }
            return View(cashPointVMs);
        }

        // GET: CashPoints/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashPoint CashPoint = _cashPointRepository.GetById(id);
            if (CashPoint == null)
            {
                return HttpNotFound();
            }
            return View(CashPoint);
        }

        // GET: CashPoints/Create
        public ActionResult Create()
        {
            ViewBag.Accounts = _accountRepository.Get().ToList();
            return View();
        }

        // POST: CashPoints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address," +
            "CashCentreId,SelectedAccountIds")] CashPointVM model)
        {
            if (ModelState.IsValid)
            {
                var CashPoint = new CashPoint
                {
                    Name = model.Name,
                    Address = model.Address,
                    //Creation = DateTime.Now,
                    //LastUpdate = DateTime.Now,
                    //LastUpdateUser = User.Identity.Name,
                    //CashCentreId = model.CashCentreId
                };
                _cashPointRepository.Create(CashPoint, model.SelectedAccountIds);
                return RedirectToAction("Index");
            }
            ViewBag.Accounts = _accountRepository.Get().ToList();
            return View();
        }

        // GET: CashPoints/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashPoint CashPoint = _cashPointRepository.GetById(id);
            if (CashPoint == null)
            {
                return HttpNotFound();
            }
            var model = new CashPointVM
            {
                Name = CashPoint.Name,
                Address = CashPoint.Address,
                //SelectedAccountIds = CashPoint.Accounts.Select(x => x.Id).ToList()
            };
            ViewBag.Accounts = _accountRepository.Get().ToList();
            return View(model);
        }

        // POST: CashPoints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,SelectedAccountIds" +
            "CashCentreId")] CashPointVM model)
        {
            var cashPoint = _cashPointRepository.GetById(model.Id);
            if (ModelState.IsValid)
            {
                cashPoint.Name = model.Name;
                cashPoint.Address = model.Address;
                cashPoint.LastUpdate = DateTime.Now;
                cashPoint.LastUpdateUser = User.Identity.Name;
                _cashPointRepository.Update(cashPoint, model.SelectedAccountIds);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: CashPoints/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashPoint CashPoint = _cashPointRepository.GetById(id);
            if (CashPoint == null)
            {
                return HttpNotFound();
            }
            return View(CashPoint);
        }

        // POST: CashPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CashPoint CashPoint = _cashPointRepository.GetById(id);
            _cashPointRepository.Delete(CashPoint.Id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cashPointRepository.Dispose();
                _accountRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
