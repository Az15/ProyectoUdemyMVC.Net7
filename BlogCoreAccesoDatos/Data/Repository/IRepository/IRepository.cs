using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository.IRepository
{
    //Interfaz Generica para Filtrar, Agregar y Remover.
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll(
            Expression<Func<T, bool >>filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            string includePropierties = null
            );

        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter =null,
            string includePropierties = null 
            );
        
        //Funciones Vacias de Agregar y Remover.(Por entidad y ID)
        void Add(T entity );
        void Remove(int id);
        void Remove(T entity);

    }
}   
