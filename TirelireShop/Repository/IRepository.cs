using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TirelireShop.DataAccess
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void InsertItem(T item);
        void DeleteItem(T item);
        void UpdateItem(T item);


    }

}
