using PresenileNotes.Entity;
using PresenileNotes.Entity.model;
using PresenileNotes.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresenileNotes.Repository
{
    public class NoteRepository : GenericRepository<Note>
    {
        public NoteRepository()
            : base(new ModelContext())
        {
        }
        public override IQueryable<Note> GetAll()
        {
            return Entities.Set<Note>().AsQueryable();
        }
        public Note GetById(int id)
        {
            return Dbset.FirstOrDefault(r => r.Id == id);
        }
        public Note Get(int id)
        {
            return Dbset.FirstOrDefault(r => r.Id == id);
        }
    }
}
