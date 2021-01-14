using PresenileNotes.Entity;
using PresenileNotes.Entity.model;
using PresenileNotes.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresenileNotes.Repository
{
    public class WorkspaceRepository : GenericRepository<Workspace>
    {
        public WorkspaceRepository()
            : base(new ModelContext())
        {
        }
        public override IQueryable<Workspace> GetAll()
        {
            return Entities.Set<Workspace>().AsQueryable();
        }
        public Workspace GetById(int id)
        {
            return Dbset.FirstOrDefault(r => r.Id == id);
        }
        public Workspace Get(int id)
        {
            return Dbset.FirstOrDefault(r => r.Id == id);
        }
    }
}
