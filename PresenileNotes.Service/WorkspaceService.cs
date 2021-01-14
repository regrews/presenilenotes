using PresenileNotes.Entity.model;
using PresenileNotes.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Claims;

namespace PresenileNotes.Service
{
   public class WorkspaceService
    {
        private readonly IRepository<Workspace> _workspaceRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Note> _noteRepository;
        private readonly IRepository<User> _userRepository;
        public WorkspaceService(IRepository<Workspace> workspaceRepository,IRepository<Category> categoryRepository,IRepository<Note> noteRepository,IRepository<User> userRepository)
        {
            this._workspaceRepository = workspaceRepository;
            this._categoryRepository = categoryRepository;
            this._noteRepository = noteRepository;
            this._userRepository = userRepository;
        }
        
        public WorkspaceService(IRepository<Workspace> workspaceRepository)
        {
            this._workspaceRepository = workspaceRepository;
        }
        public List<Workspace> GetAll(int id)
        {
            var repos = _workspaceRepository.Where(x => !x.IsDeleted && !x.IsDraft && x.UserId == id).ToList();
            return repos;
        }
        public List<Workspace> GetAllDeleted(int id)
        {
            var repos = _workspaceRepository.Where(x => !x.IsDraft && x.UserId == id).ToList();
            return repos;
        }
        public Workspace Get(int id)
        {
            var repo = _workspaceRepository.All().FirstOrDefault(x => x.Id == id);
            return repo;
        }
        public bool Add(Workspace workspace)
        {
            return _workspaceRepository.Add(workspace);
        }
        public bool Update(Workspace workspace)
        {
            return _workspaceRepository.Update(workspace);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            item.IsDeleted = true;
            Update(item);
        }
        public bool Remove (int id)
        {
            var item = Get(id);
            return _workspaceRepository.Delete(item);
        }
        public void ChangeActive(int id)
        {
            var item = Get(id);
            item.IsActive = !item.IsActive;
            Update(item);
        }
        public List<Category> GetAllCategory(int workspaceId,int userId)
        {
            CategoryService categoryService = new CategoryService(_categoryRepository);
            UserService userService = new UserService(_userRepository);
            var category = categoryService.GetAll().FindAll(x=>x.WorkspaceId==workspaceId && x.UserId == userId);
            
            return category;
        }
        public List<Note> GetAllNote(List<Category> _category)
        {
            NoteService noteService = new NoteService(_noteRepository);

            List<Note> notes = new List<Note>();
            foreach (var item in _category)
            {
                var note = noteService.GetAll().FindAll(y => y.CategoryId == item.Id);
                foreach (var x in note)
                {
                    notes.Add(x);
                }
                
            }
            return notes;
        }
    }
}
