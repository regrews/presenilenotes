using PresenileNotes.Entity.model;
using PresenileNotes.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresenileNotes.Service
{
    public class NoteService
    {
        private readonly IRepository<Note> _noteRepository;
        public NoteService(IRepository<Note> noteRepository)
        {
            this._noteRepository = noteRepository;
        }
        public List<Note> GetAll()
        {
            var repos = _noteRepository.Where(x => !x.IsDeleted && !x.IsDraft ).ToList();
            return repos;
        }
        public List<Note> GetAllDeleted()
        {
            var repos = _noteRepository.Where(x => x.IsDeleted == true && !x.IsDraft).ToList();
            return repos;
        }
        public Note Get(int id)
        {
            var repo = _noteRepository.All().FirstOrDefault(x=>x.Id == id);
            return repo;
        }
        public bool Add(Note note)
        {
            note.Class = replacing(note.Title);
            return _noteRepository.Add(note);
        }
        public bool Update(Note note)
        {
            note.Class = replacing(note.Title);
            return _noteRepository.Update(note);
        }
        public bool Delete(int id)
        {
            var item = Get(id);
            item.IsDeleted = true;
            return Update(item);
            
        }
        public void Remove(int id)
        {
            var item = Get(id);
            _noteRepository.Delete(item);
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
