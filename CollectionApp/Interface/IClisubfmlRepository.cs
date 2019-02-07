using CollectionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionApp.Interface
{
    interface IClisubfmlRepository<T> : IRepository<Clisubfml>
    {
        T Create(T model, ICollection<long> selectedClientIds);
        void Update(T model, ICollection<long> selectedClientIds);
    }
}
