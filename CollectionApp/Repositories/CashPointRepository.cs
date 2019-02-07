using CollectionApp.Interface;
using CollectionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.Repositories
{
    public class CashPointRepository : IRepository<CashPoint>
    {
        private readonly ApplicationDbContext _dbContext;

        public CashPointRepository()
        {
            _dbContext = new ApplicationDbContext();
        }

        public CashPoint Create(CashPoint model, ICollection<long> selectedAccountIds)
        {
            using (var tran = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.CashPoints.Add(model);
                    _dbContext.SaveChanges();

                    if (selectedAccountIds != null && selectedAccountIds.Any())
                    {
                        var selectedAccounts = _dbContext.Accounts.Where(x => selectedAccountIds.Contains(x.Id));

                        foreach (var selectedAccount in selectedAccounts)
                        {
                            //model.Accounts.Add(selectedAccount);
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
            var CashPoint = _dbContext.CashPoints.Find(Id);
            _dbContext.CashPoints.Remove(CashPoint);
            _dbContext.SaveChanges();
        }

        public IEnumerable<CashPoint> Get()
        {
            return _dbContext.CashPoints
                .Include("Accounts");
        }

        public CashPoint GetById(long? Id)
        {
            return _dbContext.CashPoints
                .Include("Accounts")
                .FirstOrDefault(x => x.Id == Id);
        }

        public void Update(CashPoint model, ICollection<long> selectedAccountIds)
        {
            using (var tran = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var cashPoint = _dbContext.CashPoints.Find(model.Id);

                    //cashPoint.Accounts.Clear();

                    if (selectedAccountIds != null && selectedAccountIds.Any())
                    {
                        var selectedAccounts = _dbContext.Accounts.Where(x => selectedAccountIds.Contains(x.Id));

                        foreach (var selectedAccount in selectedAccounts)
                        {
                            //model.Accounts.Add(selectedAccount);
                        }
                    }
                    _dbContext.SaveChanges();

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        #region Not used
        public void Update(CashPoint model)
        {
            throw new NotImplementedException();
        }

        public CashPoint Create(CashPoint model)
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