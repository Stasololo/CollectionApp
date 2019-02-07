using CollectionApp.Interface;
using CollectionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.Repositories
{
    public class ClisubfmlRepository : IRepository<Clisubfml>
    {
        private readonly ApplicationDbContext _dbContext;

        public ClisubfmlRepository()
        {
            _dbContext = new ApplicationDbContext();
        }

        public Clisubfml Create(Clisubfml model)
        {
            var result = _dbContext.Clisubfmls.Add(model);
            _dbContext.SaveChanges();
            return result;
        }

        public void Delete(long Id)
        {
            var clisubfml = _dbContext.Clisubfmls.Find(Id);
            _dbContext.Clisubfmls.Remove(clisubfml);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Clisubfml> Get()
        {
            return _dbContext.Clisubfmls.Include("ClientGroup");
        }

        public Clisubfml GetById(long? Id)
        {
            return _dbContext.Clisubfmls
                .Include("ClientGroup").FirstOrDefault(x => x.Id == Id);
        }

        public void Update(Clisubfml model)
        {
            var cliSubdml = _dbContext.Clisubfmls.Find(model.Id);
            cliSubdml.Name = model.Name;

            cliSubdml.Creation = model.Creation;
            cliSubdml.LastUpdate = model.LastUpdate;
            cliSubdml.LastUpdateUser = model.LastUpdateUser;
            _dbContext.SaveChanges();
        }

        public Clisubfml Create(Clisubfml model, ICollection<long> selectedClientIds)
        {
            using (var tran = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Clisubfmls.Add(model);
                    _dbContext.SaveChanges();

                    _dbContext.SaveChanges();
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

        public void Update(Clisubfml model, ICollection<long> selectedClientIds)
        {
            using (var tran = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var clisub = _dbContext.Clisubfmls.Find(model.Id);
                    clisub.ClientGroup.Clear();

                    if (selectedClientIds != null && selectedClientIds.Any())
                    {
                        var selectedClients = _dbContext.Clients.Where(x => selectedClientIds.Contains(x.Id));

                        foreach (var selectedClient in selectedClients)
                        {
                            model.ClientGroup.Add(selectedClient);
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

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}