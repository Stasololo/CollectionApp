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
    public class CitiesController : Controller
    {
        private readonly CityRepository _repo;

        public CitiesController()
        {
            _repo = new CityRepository();
        }

        // GET: Cities
        public ActionResult Index()
        {
            var cities = _repo.Get();
            return View(cities);
        }

        // GET: Cities/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = _repo.GetById(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Creation,LastUpdateUser,LastUpdate")] CityVM model)
        {
            if (ModelState.IsValid)
            {
                var city = new City
                {
                    Name = model.Name,
                    Creation = DateTime.Now,
                    LastUpdate = DateTime.Now,
                    LastUpdateUser = User.Identity.Name,
                }
;                _repo.Create(city);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = _repo.GetById(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            var model = new CityVM
            {
                Name = city.Name
            };
            return View(model);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Creation,LastUpdateUser,LastUpdate")] CityVM model)
        {
            var city = _repo.GetById(model.Id);
            if (ModelState.IsValid)
            {
                city.Name = model.Name;
                city.LastUpdate = DateTime.Now;
                city.LastUpdateUser = User.Identity.Name;


                _repo.Update(city);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = _repo.GetById(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: Cities/Delete/5
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
