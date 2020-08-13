using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TirelireShop.DataAccess
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T InsertItem(T item);
        T DeleteItem(T item);
        T UpdateItem(T item);
        T GetItem(int id);


    }

}
