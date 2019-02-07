using CollectionApp.Interface;
using CollectionApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CollectionApp.Repositories
{
    public class RuleReposiroty : IRepository<Rules>
    {
        private readonly ApplicationDbContext _dbContext;

        public RuleReposiroty()
        {
            _dbContext = new ApplicationDbContext();
        }

        public Rules Create(Rules model)
        {
            var result = _dbContext.Rules.Add(model);
            _dbContext.SaveChanges();
            return result;
        }

        public void Delete(long Id)
        {
            var rule = _dbContext.Rules.Find(Id);
            _dbContext.Rules.Remove(rule);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Rules> Get()
        {
            return _dbContext.Rules;
        }

        public Rules GetById(long? Id)
        {
            return _dbContext.Rules.FirstOrDefault(x => x.Id == Id);
        }

        public void Update(Rules model)
        {
            var rule = _dbContext.Rules.Find(model.Id);
            rule.Name = model.Name;
            rule.TypeDeposit = model.TypeDeposit;

            rule.Creation = model.Creation;
            rule.LastUpdate = model.LastUpdate;
            rule.LastUpdateUser = model.LastUpdateUser;
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}