using CollectionApp.Interface;
using CollectionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.Repositories
{
    public class CurrencyRepository : IRepository<Currency>
    {
        private readonly ApplicationDbContext _dbContext;

        public CurrencyRepository()
        {
            _dbContext = new ApplicationDbContext();
        }

        public Currency Create(Currency model)
        {
            var result = _dbContext.Currencies.Add(model);
            _dbContext.SaveChanges();
            return result;
        }

        public void Delete(long Id)
        {
            var currency = _dbContext.Currencies.Find(Id);
            _dbContext.Currencies.Remove(currency);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Currency> Get()
        {
            return _dbContext.Currencies;
        }

        public Currency GetById(long? Id)
        {
            return _dbContext.Currencies.FirstOrDefault(x => x.Id == Id);
        }

        public void Update(Currency model)
        {
            var currency = _dbContext.Currencies.Find(model.Id);
            currency.Name = model.Name;
            currency.CurrCode = model.CurrCode;
            currency.SellRate = model.SellRate;
            currency.Locked = model.Locked;

            currency.Creation = model.Creation;
            currency.LastUpdate = model.LastUpdate;
            currency.LastUpdateUser = model.LastUpdateUser;
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}