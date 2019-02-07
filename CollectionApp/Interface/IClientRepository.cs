using CollectionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionApp.Interface
{
    public interface IClientRepository<T> : IRepository<Client>
    {
        T Create(T model, ICollection<long> selectedCashCentreIds, ICollection<long> selectedAccountIds);
        void Update(T model, ICollection<long> selectedCashCentreIds, ICollection<long> selectedAccountIds);
    }
}
