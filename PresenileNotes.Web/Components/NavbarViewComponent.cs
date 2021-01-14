using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresenileNotes.Entity.model;
using PresenileNotes.Infrastructure;
using PresenileNotes.Service;
using PresenileNotes.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PresenileNotes.Web.Components
{
    public class NavbarViewComponent:ViewComponent
    {
        private readonly IRepository<Workspace> _workspaceRepository;
        private readonly WorkspaceService _workspaceService;
        public NavbarViewComponent(IRepository<Workspace> workspaceRepository)
        {
            this._workspaceRepository = workspaceRepository;
            _workspaceService = new WorkspaceService(_workspaceRepository);
        }
        public IViewComponentResult Invoke(int userId)
        {
            int workspaceId = Convert.ToInt32(HttpContext.Session.GetString("WorkspaceId"));

            HomeModel model = new HomeModel();
            model.Workspaces = _workspaceService.GetAll(userId);
            model.Workspace = _workspaceService.Get(workspaceId);
            return View(model);
        }
    }
}
