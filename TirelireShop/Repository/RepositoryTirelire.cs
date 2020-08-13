using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TirelireShop.DataAccess;

namespace TirelireShop.Repository
{
    public class RepositoryTirelire<T> : IRepository<T> where T : class
    {
        private DBTirelireShopContext _contexte;

        public RepositoryTirelire(DBTirelireShopContext contexte)
        {
            _contexte = contexte;
        }

        public T DeleteItem(T item)
        {
            _contexte.Set<T>().Remove(item);
            _contexte.SaveChanges();
            return item; 
        }

        public IEnumerable<T> GetAll()
        {
            return _contexte.Set<T>().ToList();
           
        }

        public T GetItem(int id)
        {
            return _contexte.Set<T>().Find(id);
            throw new NotImplementedException();
        }

        public T InsertItem(T item)
        {
            try
            {
                _contexte.Set<T>().Add(item);  //ajout a lieu dans le cache de l'appli ASP.NET
                _contexte.SaveChanges();
                
                return item;
            }
            catch (Exception)
            {
                //reacion a gerer
                throw;
            }

            throw new NotImplementedException();
        }

        public T UpdateItem(T item)
        {
            _contexte.Attach(item);
            _contexte.Entry(item).State = EntityState.Modified;
            _contexte.SaveChanges();
            return item;
//            _contexte.Set<T>().Update
            //throw new NotImplementedException();
        }
    }
}
