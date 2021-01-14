
using Microsoft.EntityFrameworkCore;
using PresenileNotes.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PresenileNotes.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ModelContext dbContext;
        public Repository(ModelContext dbContext)
        {
            this.dbContext = dbContext;
            this.Table = dbContext.Set<T>();
        }
        public DbSet<T> Table { get; set; }

        public bool Add(T entity)
        {
            Table.Add(entity);
            return Save();
        }

        public bool Update(T entity)
        {
            Table.UpdateRange(entity);
            return Save();
        }

        public bool Delete(T entity)
        {
            Table.Remove(entity).State = EntityState.Deleted;
            return Save();
        }

        public IQueryable<T> All()
        {
            return Table;
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> where)
        {
            return Table.Where(where);
        }

        public IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc)
        {
            if (isDesc)
                return Table.OrderByDescending(orderBy);
            return Table.OrderBy(orderBy);
        }


        private bool Save()
        {
             try
             {
                dbContext.SaveChanges();
                return true;
             }
             catch
             {
                 // TODO: Log Exceptions
                 return false;
             }
        }

        public T Single(Expression<Func<T, bool>> single)
        {
            return Table.SingleOrDefault(single);
        }

        public T FindById(object id)
        {
            return Table.Find(id);
        }
    }
}
