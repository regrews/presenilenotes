using Microsoft.EntityFrameworkCore;
using PresenileNotes.Entity;
using PresenileNotes.Entity.model;
using PresenileNotes.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresenileNotes.Repository
{
  public class CategoryRepository:GenericRepository<Category>
    {
        public CategoryRepository()
            :base(new ModelContext()) { }
        public override IQueryable<Category> GetAll()
        {
            return Entities.Set<Category>().AsQueryable();
        }
        public Category GetById(int id)
        {
            return Dbset.FirstOrDefault(r => r.Id == id);
        }
        public Category Get(int id)
        {
            return Dbset.FirstOrDefault(r => r.Id == id);
        }
    }
}
