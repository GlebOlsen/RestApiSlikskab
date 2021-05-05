using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestService.Managers
{
    interface IManager<T>
    {
        ICollection<T> GetAll();
        T GetById(int id);
        T Post(T value);
        T Update(int id, T value);
        T Delete(int id);
    }
}
