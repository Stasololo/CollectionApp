using CollectionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionApp.Interface
{
    interface IAccountRepository<T> : IRepository<Account>
    {
        T Create(T model, ICollection<long> selectedClientIds, ICollection<long> selectedCashPointIds);
        void Update(T model, ICollection<long> selectedClientIds, ICollection<long> selectedCashPointIds);
    }
}
