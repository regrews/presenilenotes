using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresenileNotes.Entity.model
{
    public class Category : Base
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int WorkspaceId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Workspace Workspace { get; set; }
        public ICollection<Note> Notes { get; set; }

    }
}
