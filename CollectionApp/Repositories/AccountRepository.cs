using CollectionApp.Interface;
using CollectionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountRepository()
        {
            _dbContext = new ApplicationDbContext();
        }

        public Account Create(Account model, ICollection<long> selectedCashPointIds)
        {
            using (var tran = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var client = _dbContext.Clients.Find(model.ClientId);
                    var currency = _dbContext.Currencies.Find(model.CurrencyId);

                    model.Client = client;
                    model.Currency = currency;

                    _dbContext.Accounts.Add(model);
                    _dbContext.SaveChanges();

                    if (selectedCashPointIds != null && selectedCashPointIds.Any())
                    {
                        var selectedCashPoints = _dbContext.CashPoints.Where(x => selectedCashPointIds.Contains(x.Id));

                        foreach (var selectedCashPoint in selectedCashPoints)
                        {
                            //model.CashPoints.Add(selectedCashPoint);
                        }
                        _dbContext.SaveChanges();
                    }

                    tran.Commit();

                    return model;
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        public void Delete(long Id)
        {
            var account = _dbContext.Accounts.Find(Id);
            _dbContext.Accounts.Remove(account);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Account> Get()
        {
            return _dbContext.Accounts
                .Include("Client")
                .Include("Currency")
                .Include("CashPoints");
        }

        public Account GetById(long? Id)
        {
            return _dbContext.Accounts
                .Include("Client")
                .Include("Currency")
                .Include("CashPoints")
                .FirstOrDefault(x => x.Id == Id);
        }

        public void Update(Account model, ICollection<long> selectedCashPointIds)
        {
            using (var tran = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var account = _dbContext.Accounts.Find(model.Id);
                    //account.CashPoints.Clear();

                    if (selectedCashPointIds != null && selectedCashPointIds.Any())
                    {
                        var selectedCashPoints = _dbContext.CashPoints.Where(x => selectedCashPointIds.Contains(x.Id));

                        foreach (var selectedCashPoint in selectedCashPoints)
                        {
                            //model.CashPoints.Add(selectedCashPoint);
                        }
                    }
                    _dbContext.SaveChanges();

                    tran.Commit();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            
        }

        #region Not used
        Account IRepository<Account>.Create(Account model)
        {
            throw new NotImplementedException();
        }

        void IRepository<Account>.Update(Account model)
        {
            throw new NotImplementedException();
        }
        #endregion

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}