using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresenileNotes.Entity.model;
using PresenileNotes.Infrastructure;
using PresenileNotes.Service;
using PresenileNotes.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresenileNotes.Web.Components
{
    public class SidebarViewComponent:ViewComponent
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Note> _noteRepository;
        private readonly IRepository<Workspace> _workspaceRepository;
        private readonly WorkspaceService _workspaceService;
        private readonly NoteService _noteService;

        public SidebarViewComponent(IRepository<Category> categoryRepository, IRepository<User> userRepository, IRepository<Note> noteRepository, IRepository<Workspace> workspaceRepository)
        {
            this._categoryRepository = categoryRepository;
            this._userRepository = userRepository;
            this._noteRepository = noteRepository;
            this._workspaceRepository = workspaceRepository;
            _workspaceService = new WorkspaceService(_workspaceRepository, _categoryRepository, _noteRepository,_userRepository);
            _noteService = new NoteService(_noteRepository);
        }
        public IViewComponentResult Invoke(int userId)
        {
            HomeModel model = new HomeModel();
            int workspaceId = Convert.ToInt32(HttpContext.Session.GetString("WorkspaceId"));
            if (workspaceId != 0) { 
                model.Categories = _workspaceService.GetAllCategory(workspaceId,userId);
                model.Notes = _workspaceService.GetAllNote(model.Categories);
                model.Workspace = _workspaceService.Get(workspaceId);
                return View(model);
            }
            else
            return View(model);

        }
    }
}
