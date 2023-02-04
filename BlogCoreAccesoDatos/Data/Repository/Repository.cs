using BlogCore.AccesoDatos.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        internal DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            Context = context;
            this.dbSet = context.Set<T>();
        }
        //Agregar
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }
        //obtener.
        public T Get(int id)
        {
            return dbSet.Find(id);
        }
        
        //Filtrar o Obtener los datos de tabla.
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includePropierties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            //Include Propierties separado por coma
            if (includePropierties != null)
            {
                foreach (var includeProperty in includePropierties.Split(new char[] {',' }, StringSplitOptions.RemoveEmptyEntries ))
                {
                    query = query.Include(includeProperty);  
                }

            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }
 

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includePropierties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            //Include Propierties separado por coma
            if (includePropierties != null)
            {
                foreach (var includeProperty in includePropierties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

            }
            return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
            T entityToRemove = dbSet.Find(id);   
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
