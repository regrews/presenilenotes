using PresenileNotes.Entity;
using PresenileNotes.Entity.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PresenileNotes.Web.Models
{
    public class DbInitializer
    {
        private readonly User _user = new User();
        public static void Initialize(ModelContext context)
        {
            context.Database.EnsureCreated();
            if (context.Users.Any()) { return; }
            var user = new User()
            {
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@admin.com",
                Password = GetPasswordHash("1"),
                Role = "Admin",
                IsActive = true
            };
            context.Users.Add(user);
            context.SaveChanges();
        }
        public static string GetPasswordHash(string password)
        {
            using (var sha1 = new SHA1Managed())
            {
                var hash = Encoding.UTF8.GetBytes(password);
                var generatedHash = sha1.ComputeHash(hash);
                var generatedHashString = Convert.ToBase64String(generatedHash);
                return generatedHashString + "P@ssw0rd!'^+";

            }
        }



    }
}

