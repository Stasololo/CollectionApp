using CollectionApp.Interface;
using CollectionApp.Models;
using CollectionApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.Repositories
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly ApplicationDbContext _dbContext;

        public ClientRepository()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IEnumerable<Client> Get()
        {
            return _dbContext.Clients
                .Include("City")
                .Include("Clisubfml")
                .Include("ClientToccs");
        }

        public Client GetById(long? id)
        {
            return _dbContext.Clients
                .Include("City")
                .Include("Clisubfml")
                .Include("ClientToccs")
                .FirstOrDefault(x => x.Id == id);
        }        

        public void Delete(long Id)
        {
            var client = _dbContext.Clients.Find(Id);
            _dbContext.Clients.Remove(client);
            _dbContext.SaveChanges();
        }
        public Client Create(Client model)
        {
            var city = _dbContext.Cities.Find(model.CityId);
            var clisub = _dbContext.Clisubfmls.Find(model.ClisubfmlId);

            model.City = city;
            model.Clisubfml = clisub;

           var result = _dbContext.Clients.Add(model);
            _dbContext.SaveChanges();
            return result;
        }

        public void Update(Client model)
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}