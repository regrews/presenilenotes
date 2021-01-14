using System;
using System.Collections.Generic;
using System.Text;

namespace PresenileNotes.Entity.model
{
    public class Note : Base
    {
        public string Title { get; set; }

        public string Context { get; set; }
        public string Icon { get; set; }
        public string Modified { get; set; }
        public string Class { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
