using CollectionApp.Models;
using CollectionApp.Repositories;
using CollectionApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CollectionApp.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly TransactionRepository _repo;

        public TransactionsController()
        {
            _repo = new TransactionRepository();
        }

        // GET: Transaction
        public ActionResult Index()
        {
            return View(_repo.Get());
        }

        // GET: Transaction/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transaction = _repo.GetById(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transaction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Creation,LastUpdateUser,LastUpdate")] TransactionVM model)
        {
            if (ModelState.IsValid)
            {
                var transaction = new Transaction
                {
                    //Creation = DateTime.Now,
                    //LastUpdate = DateTime.Now,
                    //LastUpdateUser = User.Identity.Name,
                    Name = model.Name
                };
                _repo.Create(transaction);
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Transaction/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transaction = _repo.GetById(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            var model = new TransactionVM
            {
                Name = transaction.Name
            };
            return View(model);
        }

        // POST: Transaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Creation,LastUpdateUser,LastUpdate")] TransactionVM model)
        {
            var transaction = _repo.GetById(model.Id);
            if (ModelState.IsValid)
            {
                transaction.Name = model.Name;
                //transaction.LastUpdate = DateTime.Now;
                //transaction.LastUpdateUser = User.Identity.Name;
                _repo.Update(transaction);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Transaction/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transaction = _repo.GetById(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}