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
    public class ClientsController : Controller
    {
        private readonly ClientRepository _clientRepository;
        private readonly CityRepository _cityRepository;
        private readonly ClisubfmlRepository _clisubfmlRepository;

        public ClientsController()
        {
            _clientRepository = new ClientRepository();
            _cityRepository = new CityRepository();
            _clisubfmlRepository = new ClisubfmlRepository();
        }

        // GET: Clients
        public ActionResult Index()
        {
            var clients = _clientRepository.Get().ToList();
            var clientVMs = new List<ClientVM>();
            foreach (var client in clients)
            {
                var clientVM = new ClientVM()
                {
                    Address = client.Address,
                    BIN = client.BIN,
                    CityName = client.City != null ? client.City.Name : string.Empty,
                    Name = client.Name,
                    ClisubfmlName = client.Clisubfml != null ? client.Clisubfml.Name : string.Empty,
                    Id = client.Id,
                    PostIndex = client.PostIndex,
                    ReportGroup1 = client.ReportGroup1,
                    ReportGroup2 = client.ReportGroup2,
                    ReportGroup3 = client.ReportGroup3,
                    ReportGroup4 = client.ReportGroup4,
                    //SelectedCashCenterNamesStr = client.CashCentres.Any()?client.CashCentres.Select(x => x.Name).Aggregate((a,b)=> a + ", " + b) : string.Empty,
                    //SelectedAccountNamesStr = client.Accounts.Any()?client.Accounts.Select(x => x.Name).Aggregate((a,b)=> a + ", " + b) : string.Empty
                };
                clientVMs.Add(clientVM);
            }
            return View(clientVMs);
        }

        // GET: Clients/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = _clientRepository.GetById(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(_cityRepository.Get(), "Id", "Name");
            ViewBag.ClisubfmlId = new SelectList(_clisubfmlRepository.Get(), "Id", "Name");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,BIN," +
            "Address,PostIndex,ReportGroup1,ReportGroup2,ReportGroup3," +
            "ReportGroup4,ClisubfmlId,CityId,Creation,LastUpdateUser," +
            "LastUpdate")] ClientVM model)
        {
            if (ModelState.IsValid)
            {
                var client = new Client
                {
                    Name = model.Name,
                    Address = model.Address,
                    BIN = model.BIN,
                    ReportGroup1 = model.ReportGroup1,
                    ReportGroup2 = model.ReportGroup2,
                    ReportGroup3 = model.ReportGroup3,
                    ReportGroup4 = model.ReportGroup4,
                    PostIndex = model.PostIndex,
                    //Creation = DateTime.Now,
                    //LastUpdate = DateTime.Now,
                    //LastUpdateUser = User.Identity.Name,
                    CityId = model.CityId,
                    ClisubfmlId = model.ClisubfmlId,
                };
                _clientRepository.Create(client);
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(_cityRepository.Get(), "Id", "Name", model.CityId);
            ViewBag.ClisubfmlId = new SelectList(_clisubfmlRepository.Get(), "Id", "Name", model.ClisubfmlId);
            return View();
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = _clientRepository.GetById(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            var model = new ClientVM
            {
                Name = client.Name,
                Address = client.Address,
                BIN = client.BIN,
                ReportGroup1 = client.ReportGroup1,
                ReportGroup2 = client.ReportGroup2,
                ReportGroup3 = client.ReportGroup3,
                ReportGroup4 = client.ReportGroup4,
                PostIndex = client.PostIndex,
                CityId = client.CityId,
                ClisubfmlId = client.ClisubfmlId,
                //SelectedCashCenterIds = client.CashCentres.Select(x=> x.Id).ToList()
            };
            ViewBag.CityId = new SelectList(_cityRepository.Get(), "Id", "Name", client.CityId);
            ViewBag.ClisubfmlId = new SelectList(_clisubfmlRepository.Get(), "Id", "Name", client.ClisubfmlId);
            return View(model);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,BIN,Address,PostIndex," +
            "ReportGroup1,ReportGroup2,ReportGroup3,ReportGroup4,ClisubfmlId," +
            "CityId,Creation,LastUpdateUser,LastUpdate,SelectedCashCenterIds," +
            "SelectedAccountIds")] ClientVM model)
        {
            var client = _clientRepository.GetById(model.Id);
            if (ModelState.IsValid)
            {
                client.Name = model.Name;
                client.Address = model.Address;
                client.BIN = model.BIN;
                client.ReportGroup1 = model.ReportGroup1;
                client.ReportGroup2 = model.ReportGroup2;
                client.ReportGroup3 = model.ReportGroup3;
                client.ReportGroup4 = model.ReportGroup4;
                client.PostIndex = model.PostIndex;
                //client.LastUpdate = DateTime.Now;
                //client.LastUpdateUser = User.Identity.Name;
                client.CityId = model.CityId;
                client.ClisubfmlId = model.ClisubfmlId;
                _clientRepository.Update(client);
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(_cityRepository.Get(), "Id", "Name", client.CityId);
            ViewBag.ClisubfmlId = new SelectList(_clisubfmlRepository.Get(), "Id", "Name", client.ClisubfmlId);
            return View();
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = _clientRepository.GetById(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            _clientRepository.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clientRepository.Dispose();
                _clisubfmlRepository.Dispose();
                _cityRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
