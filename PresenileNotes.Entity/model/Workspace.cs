using System;
using System.Collections.Generic;
using System.Text;

namespace PresenileNotes.Entity.model
{
    public class Workspace : Base
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
