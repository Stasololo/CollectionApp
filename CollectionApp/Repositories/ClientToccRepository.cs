using CollectionApp.Interface;
using CollectionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.Repositories
{
    public class ClientToccRepository : IRepository<ClientTocc>
    {
        private readonly ApplicationDbContext _dbContext;

        public ClientToccRepository()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ClientTocc Create(ClientTocc model, ICollection<long> selectedCashPointIds, ICollection<long> selectedAccountIds)
        {
            using (var tran = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var client = _dbContext.Clients.Find(model.ClientId);
                    var cashCentre = _dbContext.CashCentres.Find(model.CashCentreId);

                    model.Client = client;
                    model.CashCentre = cashCentre;

                    _dbContext.ClientTocc.Add(model);
                    _dbContext.SaveChanges();

                    if (selectedCashPointIds != null && selectedCashPointIds.Any())
                    {
                        var selectedCashPoints = _dbContext.CashPoints.Where(x => selectedCashPointIds.Contains(x.Id));

                        foreach (var selectedCashpoint in selectedCashPoints)
                        {
                            model.CashPoints.Add(selectedCashpoint);
                        }
                        _dbContext.SaveChanges();
                    }

                    if (selectedAccountIds != null && selectedAccountIds.Any())
                    {
                        var selectedAccounts = _dbContext.Accounts.Where(x => selectedAccountIds.Contains(x.Id));

                        foreach (var selectedAccount in selectedAccounts)
                        {
                            model.Accounts.Add(selectedAccount);
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
            throw new NotImplementedException();
        }

        public IEnumerable<ClientTocc> Get()
        {
            var clientToccs = _dbContext.ClientTocc.ToList();
            return clientToccs;
        }

        public ClientTocc GetById(long? Id)
        {
            throw new NotImplementedException();
        }

        public void Update(ClientTocc model)
        {
            throw new NotImplementedException();
        }

        #region Not used
        public ClientTocc Create(ClientTocc model)
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