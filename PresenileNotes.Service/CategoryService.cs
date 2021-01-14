using PresenileNotes.Entity.model;
using PresenileNotes.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresenileNotes.Service
{
    public class CategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        public CategoryService(IRepository<Category> categoryService)
        {
            this._categoryRepository = categoryService;
        }
        public List<Category> GetAll()
        {
            var repos = _categoryRepository.Where(x => !x.IsDeleted && !x.IsDraft ).ToList();
            return repos;
        }
        public List<Category> GetAllDeleted()
        {
            var repos = _categoryRepository.Where(x => !x.IsDraft).ToList();
            return repos;
        }
        public Category Get(int id)
        {
            var repo = _categoryRepository.All().FirstOrDefault(x => x.Id == id);
            return repo;
        }
        public bool Add(Category category)
        {
            category.Class = replacing(category.Name);
            return _categoryRepository.Add(category);
        }
        public bool Update(Category category)
        {
            category.Class = replacing(category.Name);
            return _categoryRepository.Update(category);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            item.IsDeleted = true;
            Update(item);
        }
        public void Remove(int id)
        {
            var item = Get(id);
            _categoryRepository.Delete(item);
        }
        public void ChangeActive(int id)
        {
            var item = Get(id);
            item.IsActive = !item.IsActive;
            Update(item);
        }
        public string replacing(string keyword)
        {
            char[] trChar = { 'ı', 'ğ', 'İ', 'Ğ', 'ç', 'Ç', 'ş', 'Ş', 'ö', 'Ö', 'ü', 'Ü', ' ' };
            char[] engChar = { 'i', 'g', 'I', 'G', 'c', 'C', 's', 'S', 'o', 'O', 'u', 'U', '-' };
            for (int i = 0; i < trChar.Length; i++)
            {
                keyword = keyword.Replace(trChar[i], engChar[i]);
            }
            return keyword;
        }
    }
}
