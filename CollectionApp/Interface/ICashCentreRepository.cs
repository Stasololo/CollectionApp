using CollectionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionApp.Interface
{
    interface ICashCentreRepository<T> : IRepository<CashCentre>
    {
        T Create(T model, ICollection<long> selectedCashPointIds);
        void Update(T model, ICollection<long> selectedCashPointIds);
    }
}
