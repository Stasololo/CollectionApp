using CollectionApp.Interface;
using CollectionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.Repositories
{
    public class TransactionRepository : IRepository<Transaction>
    {
        private readonly ApplicationDbContext _dbContext;

        public TransactionRepository()
        {
            _dbContext = new ApplicationDbContext();
        }

        public Transaction Create(Transaction model)
        {
            var result = _dbContext.Transactions.Add(model);
            _dbContext.SaveChanges();
            return result;
        }

        public void Delete(long Id)
        {
            var transaction = _dbContext.Transactions.Find(Id);
            _dbContext.Transactions.Remove(transaction);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Transaction> Get()
        {
            return _dbContext.Transactions
                .Include("User");
        }

        public Transaction GetById(long? Id)
        {
            return _dbContext.Transactions
                .Include("User")
                .FirstOrDefault(x => x.Id == Id);
        }

        public void Update(Transaction model)
        {
            var transaction = _dbContext.Transactions.Find(model.Id);
            transaction.UserId = model.UserId;

            transaction.Creation = model.Creation;
            transaction.LastUpdate = model.LastUpdate;
            transaction.LastUpdateUser = model.LastUpdateUser;
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}