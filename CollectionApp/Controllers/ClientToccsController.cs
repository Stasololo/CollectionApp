using CollectionApp.Models;
using CollectionApp.Repositories;
using CollectionApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollectionApp.Controllers
{
    public class ClientToccsController : Controller
    {
        private readonly ClientToccRepository _clientToccRepository;
        private readonly ClientRepository _clientRepository;
        private readonly CashCentreRepository _cashCentreRepository;
        private readonly CashPointRepository _cashPointRepository;
        private readonly AccountRepository _accountRepository;

        public ClientToccsController()
        {
            _clientToccRepository = new ClientToccRepository();
            _clientRepository = new ClientRepository();
            _cashCentreRepository = new CashCentreRepository();
            _cashPointRepository = new CashPointRepository();
            _accountRepository = new AccountRepository();
        }

        // GET: ClientToccs
        public ActionResult Index()
        {
            var clientToccs = _clientToccRepository.Get();
            var clientToccVMs = new List<ClientToccIndexVM>();
            foreach (var clientTocc in clientToccs)
            {
                var clientToccVM = new ClientToccIndexVM()
                {
                    Id = clientTocc.Id,
                    Name = clientTocc.Client.Name != null ? clientTocc.Client.Name : string.Empty + "/" + clientTocc.CashCentre.Name != null ? clientTocc.CashCentre.Name : string.Empty,
                    SelectedCashPointNamesStr = clientTocc.CashPoints.Any() ? clientTocc.CashPoints.Select(x => x.Name).Aggregate((a, b) => a + ", " + b) : string.Empty,
                    SelectedAccountNamesStr = clientTocc.Accounts.Any() ? clientTocc.Accounts.Select(x => x.Name).Aggregate((a, b) => a + ", " + b) : string.Empty
                };
            }
            return View();
        }

        // GET: ClientToccs/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(_clientRepository.Get(), "Id", "Name");
            ViewBag.CashCentreId = new SelectList(_cashCentreRepository.Get(), "Id", "Name");
            ViewBag.CashPoints = _cashPointRepository.Get().ToList();
            ViewBag.Accounts = _accountRepository.Get()
                //.Where(x => x.ClientToccId == )
                .ToList();
            return View();
        }

        // POST: ClientToccs/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,ClientId," +
            "CashCentreId,Creation,LastUpdateUser," +
            "LastUpdate,SelectedCashPointIds,SelectedAccountIds")] ClientToccVM model)
        {
            if (ModelState.IsValid)
            {
                var clientTocc = new ClientTocc
                {
                    ClientId = model.ClientId,
                    CashCentreId = model.CashCentreId,
                    //LastUpdate = DateTime.Now,
                    //Creation = DateTime.Now,
                    //LastUpdateUser = User.Identity.Name
                };
                _clientToccRepository.Create(clientTocc, model.SelectedCashPointIds, model.SelectedAccountIds);
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }

            ViewBag.ClientId = new SelectList(_clientRepository.Get(), "Id", "Name");
            ViewBag.CashCentreId = new SelectList(_cashCentreRepository.Get(), "Id", "Name");
            ViewBag.CashPoints = _cashPointRepository.Get().ToList();
            ViewBag.Accounts = _accountRepository.Get().ToList();
            return View();
        }

        #region Test DevExtreme
        public ActionResult DevCreate()
        {
            ViewBag.ClientId = new SelectList(_clientRepository.Get(), "Id", "Name");
            ViewBag.CashCentreId = new SelectList(_cashCentreRepository.Get(), "Id", "Name");
            ViewBag.CashPoints = _cashPointRepository.Get().ToList();
            ViewBag.Accounts = _accountRepository.Get()
                //.Where(x => x.ClientToccId == )
                .ToList();
            return View();
        }

        [HttpPost]
        public ActionResult DevCreate([Bind(Include = "Id,ClientId," +
            "CashCentreId,Creation,LastUpdateUser," +
            "LastUpdate,SelectedCashPointIds,SelectedAccountIds")] ClientToccVM model)
        {
            if (ModelState.IsValid)
            {
                var clientTocc = new ClientTocc
                {
                    ClientId = model.ClientId,
                    CashCentreId = model.CashCentreId,
                    //LastUpdate = DateTime.Now,
                    //Creation = DateTime.Now,
                    //LastUpdateUser = User.Identity.Name
                };
                _clientToccRepository.Create(clientTocc, model.SelectedCashPointIds, model.SelectedAccountIds);
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }

            ViewBag.ClientId = new SelectList(_clientRepository.Get(), "Id", "Name");
            ViewBag.CashCentreId = new SelectList(_cashCentreRepository.Get(), "Id", "Name");
            ViewBag.CashPoints = _cashPointRepository.Get().ToList();
            ViewBag.Accounts = _accountRepository.Get().ToList();
            return View();
        }
        #endregion

        // GET: ClientToccs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientToccs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientToccs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientToccs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientToccs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
