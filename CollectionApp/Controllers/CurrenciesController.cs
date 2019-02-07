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
    public class CurrenciesController : Controller
    {
        private readonly CurrencyRepository _repo;

        public CurrenciesController()
        {
            _repo = new CurrencyRepository();
        }

        // GET: Currencies
        public ActionResult Index()
        {
            return View(_repo.Get());
        }

        // GET: Currencies/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Currency currency = _repo.GetById(id);
            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        // GET: Currencies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Currencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CurrCode,Rate,SellRate,Locked")] CurrencyVM model)
        {
            if (ModelState.IsValid)
            {
                var currency = new Currency
                {
                    //Creation = DateTime.Now,
                    //LastUpdate = DateTime.Now,
                    //LastUpdateUser = User.Identity.Name,
                    CurrCode = model.CurrCode,
                    Locked = model.Locked,
                    Name = model.Name,
                    //Rate = model.Rate,
                    SellRate = model.SellRate
                };

                _repo.Create(currency);
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Currencies/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Currency currency = _repo.GetById(id);
            if (currency == null)
            {
                return HttpNotFound();
            }
            var model = new CurrencyVM
            {
                Name = currency.Name,
                CurrCode = currency.CurrCode,
                Locked = currency.Locked,
                SellRate = currency.SellRate
            };
            return View(model);
        }

        // POST: Currencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CurrCode,Rate,SellRate,Locked,LastUpdateUser")] CurrencyVM model)
        {
            var currency = _repo.GetById(model.Id);
            if (ModelState.IsValid)
            {
                currency.Name = model.Name;
                currency.SellRate = model.SellRate;
                currency.Locked = model.Locked;
                currency.CurrCode = model.CurrCode;
                //currency.LastUpdate = DateTime.Now;
                //currency.LastUpdateUser = User.Identity.Name;
                _repo.Update(currency);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Currencies/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Currency currency = _repo.GetById(id);
            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        // POST: Currencies/Delete/5
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
