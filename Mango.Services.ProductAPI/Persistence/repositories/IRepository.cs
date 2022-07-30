using Mango.Kernal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Persistence.repositories
{
    public interface IRepository<T> where T : Entity
    {
         T Get(long Id);
        IList<T> GetAll();
        T Update(T entity);
        T Delete(long Id);
        T Create(T entity);

    }
}
