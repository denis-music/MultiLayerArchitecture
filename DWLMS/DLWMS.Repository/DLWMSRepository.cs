using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLWMS.Repository
{
    public interface IDLWMSRepository<TEntity>
    {
        void Add(TEntity obj);
        void Remove(TEntity obj);
        void Update(TEntity obj);
        IEnumerable<TEntity> GetAll();//!?

    }
    public class DLWMSRepository<TEntity> : IDLWMSRepository<TEntity> where TEntity : class
    {
        DLWMSDbContext dbContext;
        DbSet<TEntity> dbSet;

        public DLWMSRepository(DLWMSDbContext db)
        {
            dbContext = db;
            dbSet = dbContext.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            dbSet.Add(obj);
            dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public void Remove(TEntity obj)
        {
            dbSet.Remove(obj);
            dbContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            dbContext.Entry(obj).State = EntityState.Modified;
            dbContext.SaveChanges();

        }
    }
}
