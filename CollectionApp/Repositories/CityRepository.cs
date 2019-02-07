using CollectionApp.Interface;
using CollectionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.Repositories
{
    public class CityRepository : IRepository<City>
    {
        private readonly ApplicationDbContext _dbContext;

        public CityRepository()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IEnumerable<City> Get()
        {
            return _dbContext.Cities;
        }

        public City GetById(long? Id)
        {
            return _dbContext.Cities.FirstOrDefault(x => x.Id == Id);
        }

        public City Create(City City)
        {
            var result = _dbContext.Cities.Add(City);
            _dbContext.SaveChanges();
            return result;
        }

        public void Delete(long Id)
        {
            var City = _dbContext.Cities.Find(Id);
            _dbContext.Cities.Remove(City);
            _dbContext.SaveChanges();
        }

        public void Update(City model)
        {
            var city = _dbContext.Cities.Find(model.Id);
            city.Name = model.Name;
            city.Creation = model.Creation;
            city.LastUpdate = model.LastUpdate;
            city.LastUpdateUser = model.LastUpdateUser;
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}