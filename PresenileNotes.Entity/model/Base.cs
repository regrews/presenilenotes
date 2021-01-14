using System;
using System.Collections.Generic;
using System.Text;

namespace PresenileNotes.Entity.model
{
   public class Base
    {
        public Base()
        {
            IsActive = true;
            IsDeleted = false;
            IsReadOnly = false;
            IsDraft = false;
            Order = 9999;
            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
        }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsDraft { get; set; }
        public int Order { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
