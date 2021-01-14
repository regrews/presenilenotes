using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PresenileNotes.Entity.model
{
    public class User : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<Category> Categories { get; set; }
        public ICollection<Workspace> Workspaces { get; set; }
        public ICollection<Note> Notes { get; set; }

    }
}
