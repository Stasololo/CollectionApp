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
    public class ClisubfmlsController : Controller
    {
        private readonly ClisubfmlRepository _clisubfmlRepository;
        private readonly ClientRepository _clientRepository;

        public ClisubfmlsController()
        {
            _clisubfmlRepository = new ClisubfmlRepository();
            _clientRepository = new ClientRepository();
        }

        // GET: Clisubfmls
        public ActionResult Index()
        {
            
            var cliSubs = _clisubfmlRepository.Get().ToList();
            return View(cliSubs);
        }

        // GET: Clisubfmls/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clisubfml clisubfml = _clisubfmlRepository.GetById(id);
            if (clisubfml == null)
            {
                return HttpNotFound();
            }
            return View(clisubfml);
        }

        // GET: Clisubfmls/Create
        public ActionResult Create()
        {
            ViewBag.Clients = _clientRepository.Get().ToList();
            return View();
        }

        // POST: Clisubfmls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Creation," +
            "LastUpdateUser,LastUpdate," +
            "selectedClientIds")] ClisubfmlVM model)
        {
            if (ModelState.IsValid)
            {
                var clisubfml = new Clisubfml
                {
                    //Creation = DateTime.Now,
                    //LastUpdate = DateTime.Now,
                    //LastUpdateUser = User.Identity.Name,
                    Name = model.Name                    
                };
                _clisubfmlRepository.Create(clisubfml, model.SelectedClientIds);
                return RedirectToAction("Index");
            }

            ViewBag.Clients = _clientRepository.Get().ToList();
            return View();
        }

        // GET: Clisubfmls/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clisubfml clisubfml = _clisubfmlRepository.GetById(id);
            if (clisubfml == null)
            {
                return HttpNotFound();
            }
            var model = new ClisubfmlVM
            {
                Name = clisubfml.Name,
                SelectedClientIds = clisubfml.ClientGroup.Select(x => x.Id).ToList()
            };
            ViewBag.Clients = _clientRepository.Get().ToList();
            return View(model);
        }

        // POST: Clisubfmls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Creation,LastUpdateUser," +
            "LastUpdate,SelectedClientIds")] ClisubfmlVM model)
        {
            var clisubfml = _clisubfmlRepository.GetById(model.Id);
            if (ModelState.IsValid)
            {
                clisubfml.Name = model.Name;
                //clisubfml.LastUpdate = DateTime.Now;
                //clisubfml.LastUpdateUser = User.Identity.Name;
                _clisubfmlRepository.Update(clisubfml, model.SelectedClientIds);
                return RedirectToAction("Index");
            }
            ViewBag.Clients = _clientRepository.Get().ToList();
            return View();
        }

        // GET: Clisubfmls/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clisubfml = _clisubfmlRepository.GetById(id);
            if (clisubfml == null)
            {
                return HttpNotFound();
            }
            return View(clisubfml);
        }

        // POST: Clisubfmls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            _clisubfmlRepository.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clisubfmlRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
