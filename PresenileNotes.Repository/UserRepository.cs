using PresenileNotes.Entity;
using PresenileNotes.Entity.model;
using PresenileNotes.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresenileNotes.Repository
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository()
            : base(new ModelContext())
        {
        }
        public override IQueryable<User> GetAll()
        {
            return Entities.Set<User>().AsQueryable();
        }
        public User GetById(int id)
        {
            return Dbset.FirstOrDefault(r => r.Id == id);
        }
        public User Get(int id)
        {
            return Dbset.FirstOrDefault(r => r.Id == id);
        }
        public User Login(string username, string password)
        {
            return Dbset.FirstOrDefault(r => r.Email == username && r.Password == password);
        }
    }
}
