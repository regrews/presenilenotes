using PresenileNotes.Entity.model;
using PresenileNotes.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PresenileNotes.Service
{
   public class UserService
    {
        private readonly IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            this._userRepository = userRepository;
        }
        public List<User> GetAll()
        {
            var repos = _userRepository.Where(x => !x.IsDeleted && !x.IsDraft).ToList();
            return repos;
        }
        public List<User> GetAllDeleted()
        {
            var repos = _userRepository.Where(x =>  !x.IsDraft).ToList();
            return repos;
        }
        public User Get(int id)
        {
            var repo = _userRepository.All().FirstOrDefault(x => x.Id == id);
            return repo;
        }
        public bool Add(User user)
        {
            user.Password = GetPasswordHash(user.Password);
            return _userRepository.Add(user);
        }
        public bool Update(User user)
        {
            return _userRepository.Update(user);
        }
        public bool UpdatePassword(User user)
        {
            user.Password = GetPasswordHash(user.Password);
            return _userRepository.Update(user);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            item.IsDeleted = true;
            item.ModifiedOn = DateTime.Now;
            Update(item);
        }
        public void ChangeActive(int id)
        {
            var item = Get(id);
            item.IsActive = !item.IsActive;
            Update(item);
        }
        public bool Login(string email, string password)
        {
            var user = _userRepository.All().FirstOrDefault(x => x.Email == email && x.Password == GetPasswordHash(password) && x.IsDeleted != true);
            if (user != null) return true;
            else return false;
        }
        public string GetPasswordHash(string password)
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
