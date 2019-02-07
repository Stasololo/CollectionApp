using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionApp.Interface
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();

        T GetById(long? Id);

        T Create(T model);

        void Delete(long Id);

        void Update(T model);
    }
}
