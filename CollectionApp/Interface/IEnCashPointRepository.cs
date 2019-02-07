using CollectionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionApp.Interface
{
    interface ICashPointRepository<T> : IRepository<CashPoint>
    {
        T Create(T model, ICollection<long> selectedAccountIds);
        void Update(T model, ICollection<long> selectedAccountIds);
    }
}
