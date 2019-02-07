using CollectionApp.Interface;
using CollectionApp.Models;
using CollectionApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.Repositories
{
    public class CashCentreRepository : IRepository<CashCentre>
    {
        private readonly ApplicationDbContext _dbContext;

        public CashCentreRepository()
        {
            _dbContext = new ApplicationDbContext();
        }

        public CashCentre Create(CashCentre model)
        {
            _dbContext.CashCentres.Add(model);
            _dbContext.SaveChanges();
            return model;
        }
       

        public void Delete(long Id)
        {
            var cashCentre = _dbContext.CashCentres.Find(Id);
            _dbContext.CashCentres.Remove(cashCentre);
            _dbContext.SaveChanges();
        }

        public IEnumerable<CashCentre> Get()
        {
            return _dbContext.CashCentres
                .Include("City")
                .Include("ClientToccs");
        }

        public CashCentre GetById(long? Id)
        {
            return _dbContext.CashCentres
                .Include("City")
                .Include("ClientToccs")
                .FirstOrDefault(x => x.Id == Id);
        }

        public void Update(CashCentre model)
        {
            var cashCentre = _dbContext.CashCentres.Find(model.Id);

            cashCentre.TimeZone = model.TimeZone;
            cashCentre.Name = model.Name;
            cashCentre.Creation = model.Creation;
            cashCentre.LastUpdate = model.LastUpdate;
            cashCentre.LastUpdateUser = model.LastUpdateUser;
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        
    }
}