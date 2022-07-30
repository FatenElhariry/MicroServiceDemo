using Mango.Kernal.Models;
using Mango.Services.ProductAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Persistence.repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        ApplicationDbContext _dbcontext ;
        public Repository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        protected virtual void _beforeUpdate(T entity) {}
        protected virtual void _beforeCreate(T entity) { }
        public T Create(T entity)
        {
            var record =  GetQueryable().Add(entity).Entity;
            _dbcontext.SaveChanges();
            return record;
        }

        public T Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public T Get(long Id)
        {
            return GetQueryable().Find(Id);
        }

        public IList<T> GetAll()
        {
            return GetQueryable().ToList();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        protected virtual DbSet<T> GetQueryable()
        {
            return _dbcontext.Set<T>();
        }
    }
}
