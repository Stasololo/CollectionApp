using CollectionApp.Interface;
using CollectionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.Repositories
{
    public class DenominationRepository : IRepository<Denomination>
    {
        private readonly ApplicationDbContext _dbContext;

        public DenominationRepository()
        {
            _dbContext = new ApplicationDbContext();
        }

        public Denomination Create(Denomination model)
        {
            var currency = _dbContext.Currencies.Find(model.Id);
            model.Currency = currency;
            var result = _dbContext.Denominations.Add(model);
            _dbContext.SaveChanges();
            return result;
        }

        public void Delete(long Id)
        {
            var denommination = _dbContext.Denominations.Find(Id);
            _dbContext.Denominations.Remove(denommination);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Denomination> Get()
        {
            return _dbContext.Denominations
                .Include("Currency");
        }

        public Denomination GetById(long? Id)
        {
            return _dbContext.Denominations
                .Include("Currency")
                .FirstOrDefault(x => x.Id == Id);
        }

        public void Update(Denomination model)
        {
            var denomination = _dbContext.Denominations.Find(model.Id);
            denomination.Name = model.Name;
            denomination.Value = model.Value;
            denomination.ValidDate = model.ValidDate;

            denomination.CurrencyId = model.CurrencyId;

            denomination.Creation = model.Creation;
            denomination.LastUpdate = model.LastUpdate;
            denomination.LastUpdateUser = model.LastUpdateUser;
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}