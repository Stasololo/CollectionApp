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
    public class CashCentresController : Controller
    {
        private readonly CashCentreRepository _cashCentreRepository;
        private readonly CityRepository _cityRepository;

        public CashCentresController()
        {
            _cashCentreRepository = new CashCentreRepository();
            _cityRepository = new CityRepository();
        }

        // GET: CashCentres
        public ActionResult Index()
        {
            var cashCentres = _cashCentreRepository.Get().ToList();
            var cashCentreVMs = new List<CashCentreVM>();
            foreach (var cashCentre in cashCentres)
            {
                var cashCentreVM = new CashCentreVM()
                {
                    Id = cashCentre.Id,
                    TimeZone = cashCentre.TimeZone,
                    Name = cashCentre.Name,
                    CityName = cashCentre.City != null ? cashCentre.City.Name : string.Empty,
                    ParentName = cashCentre.Parent != null ? cashCentre.Parent.Name : string.Empty,
                };
                cashCentreVMs.Add(cashCentreVM);
            }
            return View(cashCentreVMs);
        }

        // GET: CashCentres/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashCentre cashCentre = _cashCentreRepository.GetById(id);
            if (cashCentre == null)
            {
                return HttpNotFound();
            }
            return View(cashCentre);
        }

        // GET: CashCentres/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(_cityRepository.Get(), "Id", "Name");
            ViewBag.ParentId = new SelectList(_cashCentreRepository.Get(), "Id", "Name");
            return View();
        }

        // POST: CashCentres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TimeZone,Name,CityId," +
            "ParentId,Creation,LastUpdateUser,LastUpdate")] CashCentreVM model)
        {
            if (ModelState.IsValid)
            {
                var cashCentre = new CashCentre
                {
                    TimeZone = model.TimeZone,
                    Name = model.Name,
                    CityId = model.CityId,
                    ParentId = model.ParentId,
                    //Creation = DateTime.Now,
                    //LastUpdate = DateTime.Now,
                    //LastUpdateUser = User.Identity.Name,
                };

                _cashCentreRepository.Create(cashCentre);
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(_cityRepository.Get(), "Id", "Name");
            ViewBag.ParentId = new SelectList(_cashCentreRepository.Get(), "Id", "Name", model.ParentId);
            return View();
        }

        // GET: CashCentres/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashCentre cashCentre = _cashCentreRepository.GetById(id);
            if (cashCentre == null)
            {
                return HttpNotFound();
            }
            var model = new CashCentreVM
            {
                TimeZone = cashCentre.TimeZone,
                Name = cashCentre.Name,
                CityId = cashCentre.CityId,
                ParentId = cashCentre.ParentId,
            };
            ViewBag.CityId = new SelectList(_cityRepository.Get(), "Id", "Name", cashCentre.CityId);
            ViewBag.ParentId = new SelectList(_cashCentreRepository.Get(), "Id", "Name", cashCentre.ParentId);
            return View(model);
        }

        // POST: CashCentres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TimeZone,Name,CityId,ParentId," +
            "Creation,LastUpdateUser,LastUpdate")] CashCentreVM model)
        {
            var cashCentre = _cashCentreRepository.GetById(model.Id);
            if (ModelState.IsValid)
            {
                cashCentre.Name = model.Name;
                cashCentre.TimeZone = model.TimeZone;
                cashCentre.CityId = model.CityId;
                cashCentre.ParentId = model.ParentId;
                //cashCentre.LastUpdate = DateTime.Now;
                //cashCentre.LastUpdateUser = User.Identity.Name;
                _cashCentreRepository.Update(cashCentre);
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(_cityRepository.Get(), "Id", "Name", cashCentre.CityId);
            ViewBag.ParentId = new SelectList(_cashCentreRepository.Get(), "Id", "Name", cashCentre.ParentId);
            return View();
        }

        // GET: CashCentres/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashCentre cashCentre = _cashCentreRepository.GetById(id);
            if (cashCentre == null)
            {
                return HttpNotFound();
            }
            return View(cashCentre);
        }

        // POST: CashCentres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            _cashCentreRepository.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cashCentreRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
