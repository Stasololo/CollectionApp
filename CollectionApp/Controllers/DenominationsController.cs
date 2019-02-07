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
    public class DenominationsController : Controller
    {
        private readonly DenominationRepository _denominationRepository;
        private readonly CurrencyRepository _currencyRepository;

        public DenominationsController()
        {
            _denominationRepository = new DenominationRepository();
            _currencyRepository = new CurrencyRepository();
        }

        // GET: Denominations
        public ActionResult Index()
        {
            var denominations = _denominationRepository.Get();
            return View(denominations);
        }

        // GET: Denominations/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Denomination denomination = _denominationRepository.GetById(id);
            if (denomination == null)
            {
                return HttpNotFound();
            }
            return View(denomination);
        }

        // GET: Denominations/Create
        public ActionResult Create()
        {
            ViewBag.CurrencyId = new SelectList(_currencyRepository.Get(), "Id", "Name");
            return View();
        }

        // POST: Denominations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Value,ValidDate,CurrencyId,LastUpdateUser")] DenominationVM model)
        {
            if (ModelState.IsValid)
            {
                var denomination = new Denomination
                {
                    Creation = DateTime.Now,
                    LastUpdate = DateTime.Now,
                    LastUpdateUser = User.Identity.Name,
                    Name = model.Name,
                    Value = model.Value,
                    CurrencyId = model.CurrencyId,
                    ValidDate = model.ValidDate
                };
                _denominationRepository.Create(denomination);
                return RedirectToAction("Index");
            }

            ViewBag.CurrencyId = new SelectList(_currencyRepository.Get(), "Id", "Name", model.CurrencyId);
            return View();
        }

        // GET: Denominations/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Denomination denomination = _denominationRepository.GetById(id);
            if (denomination == null)
            {
                return HttpNotFound();
            }
            var model = new DenominationVM
            {
                CurrencyId = denomination.CurrencyId,
                Name = denomination.Name,
                ValidDate = denomination.ValidDate,
                Value = denomination.Value
            };
            ViewBag.CurrencyId = new SelectList(_currencyRepository.Get(), "Id", "Name", denomination.CurrencyId);
            return View(model);
        }

        // POST: Denominations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Value,ValidDate,CurrencyId,Creation,LastUpdateUser,LastUpdate")] DenominationVM model)
        {
            var denomination = _denominationRepository.GetById(model.Id);
            if (ModelState.IsValid)
            {
                denomination.Value = model.Value;
                denomination.Name = model.Name;
                denomination.ValidDate = model.ValidDate;
                denomination.CurrencyId = model.CurrencyId;
                denomination.LastUpdate = DateTime.Now;
                denomination.LastUpdateUser = User.Identity.Name;
                _denominationRepository.Update(denomination);
                return RedirectToAction("Index");
            }
            ViewBag.CurrencyId = new SelectList(_currencyRepository.Get(), "Id", "Name", denomination.CurrencyId);
            return View();
        }

        // GET: Denominations/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Denomination denomination = _denominationRepository.GetById(id);
            if (denomination == null)
            {
                return HttpNotFound();
            }
            return View(denomination);
        }

        // POST: Denominations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            _denominationRepository.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _denominationRepository.Dispose();
                _currencyRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
