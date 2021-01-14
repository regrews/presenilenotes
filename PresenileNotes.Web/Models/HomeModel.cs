using PresenileNotes.Entity.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresenileNotes.Web.Models
{
    public class HomeModel
    {
        public Note Note { get; set; }
        public List<Note> Notes { get; set; }
        public Workspace Workspace { get; set; }
        public List<Workspace> Workspaces { get; set; }
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
        public User User { get; set; }
        public List<User> Users { get; set; }

    }
}
