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
    public class AccountsController : Controller
    {
        private readonly AccountRepository _accountRepository;
        private readonly ClientRepository _clientRepository;
        private readonly CurrencyRepository _currencyRepository;
        private readonly CashPointRepository _cashPointRepository;

        public AccountsController()
        {
            _accountRepository = new AccountRepository();
            _clientRepository = new ClientRepository();
            _currencyRepository = new CurrencyRepository();
            _cashPointRepository = new CashPointRepository();
        }

        // GET: Accounts
        public ActionResult Index()
        {
            var accounts = _accountRepository.Get();
            var accountVMs = new List<AccountVM>();
            foreach (var account in accounts)
            {
                var accountVM = new AccountVM()
                {
                    Id = account.Id,
                    Name = account.Name,
                    CurrencyName = account.Currency != null ? account.Currency.Name : string.Empty,
                    ClientName = account.Client != null ? account.Client.Name : string.Empty,
                    //SelectedCashPointNamesStr = account.CashPoints.Any() ? account.CashPoints.Select(x => x.Name).Aggregate((a, b) => a + ", " + b) : string.Empty
                };
                accountVMs.Add(accountVM);
            }
            return View(accountVMs);
        }

        // GET: Accounts/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = _accountRepository.GetById(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(_clientRepository.Get(), "Id", "Name");
            ViewBag.CurrencyId = new SelectList(_currencyRepository.Get(), "Id", "Name");
            ViewBag.CashPoints = _cashPointRepository.Get();
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,SelectedCashPointIds," +
            "CurrencyId,ClientId")] AccountVM model)
        {
            if (ModelState.IsValid)
            {
                var account = new Account
                {
                    Name = model.Name,
                    ClientId = model.ClientId,
                    CurrencyId = model.CurrencyId,
                    Creation = DateTime.Now,
                    LastUpdate = DateTime.Now,
                    LastUpdateUser = User.Identity.Name.ToString()
                };
                _accountRepository.Create(account, model.SelectedCashPointIds);
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(_clientRepository.Get(), "Id", "Name", model.ClientId);
            ViewBag.CurrencyId = new SelectList(_currencyRepository.Get(), "Id", "Name", model.CurrencyId);
            ViewBag.CashPoints = _cashPointRepository.Get();
            return View();
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = _accountRepository.GetById(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            var model = new AccountVM
            {
                ClientId = account.ClientId,
                Name = account.Name,
                CurrencyId = account.CurrencyId,
            };
            ViewBag.ClientId = new SelectList(_clientRepository.Get(), "Id", "Name", account.ClientId);
            ViewBag.CurrencyId = new SelectList(_currencyRepository.Get(), "Id", "Name", account.CurrencyId);
            ViewBag.CashPoints = _cashPointRepository.Get();
            return View(model);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SelectedCashPointIds," +
            "CurrencyId,ClientToccId,ClientId")] AccountVM model)
        {
            var account = _accountRepository.GetById(model.Id);
            if (ModelState.IsValid)
            {
                account.Name = model.Name;
                account.CurrencyId = model.CurrencyId;
                account.ClientId = model.ClientId;
                account.LastUpdate = DateTime.Now;
                account.LastUpdateUser = User.Identity.Name;
                _accountRepository.Update(account, model.SelectedCashPointIds);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = _accountRepository.GetById(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            _accountRepository.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _accountRepository.Dispose();
                _clientRepository.Dispose();
                _currencyRepository.Dispose();
                _cashPointRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
