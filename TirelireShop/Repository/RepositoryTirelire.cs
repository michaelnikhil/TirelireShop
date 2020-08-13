using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TirelireShop.DataAccess;

namespace TirelireShop.Repository
{
    public class RepositoryTirelire<T> : IRepository<T> where T : class
    {
        public void DeleteItem(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void InsertItem(T item)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(T item)
        {
            throw new NotImplementedException();
        }
    }
}
