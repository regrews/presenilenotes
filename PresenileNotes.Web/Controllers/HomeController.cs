using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PresenileNotes.Entity.model;
using PresenileNotes.Infrastructure;
using PresenileNotes.Service;
using PresenileNotes.Web.Models;

namespace PresenileNotes.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Note> _noteRepository;
        private readonly IRepository<Workspace> _workspaceRepository;
        private readonly UserService _userService;
        private readonly WorkspaceService _workspaceService;
        private readonly NoteService _noteService;
        private readonly CategoryService _categoryService;
        private readonly IHttpContextAccessor _httpContextAccessor;


        [ActivatorUtilitiesConstructor]
        public HomeController(IRepository<Category> categoryRepository, IRepository<User> userRepository, IRepository<Note> noteRepository, IRepository<Workspace> workspaceRepository, IHttpContextAccessor httpContextAccessor)
        {
            this._categoryRepository = categoryRepository;
            this._userRepository = userRepository;
            this._noteRepository = noteRepository;
            this._workspaceRepository = workspaceRepository;
            this._userService = new UserService(_userRepository);
            _workspaceService = new WorkspaceService(_workspaceRepository, _categoryRepository, _noteRepository, _userRepository);
            _noteService = new NoteService(_noteRepository);
            _categoryService = new CategoryService(_categoryRepository);
            _httpContextAccessor = httpContextAccessor;
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public int GetUserID()
        {
            var email = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            var user = _userService.GetAll().FirstOrDefault(x => x.Email == email);
            return user.Id;
        }
        public IActionResult Index()
        {
            HomeModel model = new HomeModel();

            return View();
        }
        [HttpGet]
        public IActionResult Index(int? id)
        {
            if (id == null) id = 0;
            //ViewBag.workspaceId  = id;
            HttpContext.Session.SetString("WorkspaceId", id.ToString());
            var email = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            var userId = _userService.GetAll().FirstOrDefault(x => x.Email == email);
            ViewBag.UserId = userId.Id;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Note(int id)
        {
            HomeModel model = new HomeModel();
            int userId = GetUserID();
            ViewBag.UserId = userId;
            model.Note = _noteService.Get(id);
            model.Category = _categoryService.Get(model.Note.CategoryId);
            if (model.Note != null)
            {
                if (model.Note.UserId != userId) return null;
                else return View(model);
            }
            else return null;
        }
        [HttpPost]
        public IActionResult Note(int noteId, string title, string context)
        {
            var UserId = GetUserID();
            var note = _noteService.GetAll().FirstOrDefault(x => x.Id == noteId && x.UserId == UserId);
            ViewBag.UserId = UserId;
            if (note != null)
            {
                note.Title = title;
                note.Modified = note.Context;
                note.Context = context;
                var test = _noteService.Update(note);
                return Json(true);
            }
            //return RedirectToAction("Note", "Home", new { id = noteId });
            return Json(false);
        }
        [HttpPost]
        public IActionResult ModifiedNote(int noteId, string context)
        {
            var UserId = GetUserID();
            var note = _noteService.GetAll().FirstOrDefault(x => x.Id == noteId && x.UserId == UserId);
            if (note != null)
            {
                note.Modified = context;
                note.ModifiedOn = DateTime.Now;
                var test = _noteService.Update(note);
                return Json(true);
            }
            return Json(false);
        }
        [HttpGet]
        public IActionResult CreateNote(int id)
        {
            HomeModel model = new HomeModel();
            int userId = GetUserID();
            Note note = new Entity.model.Note();
            bool isOK = false;
            model.Category = _categoryService.GetAll().FirstOrDefault(x => x.Id == id && x.UserId == userId);
            model.User = _userService.GetAll().FirstOrDefault(x => x.Id == userId);
            if (model.Category != null)
            {
                note.Category = model.Category;
                note.CategoryId = id;
                note.UserId = userId;
                note.Modified = null;
                // model.Note.User = model.User;
                note.Title = "New Note";
                note.Context = "Content New Note";
                isOK = _noteService.Add(note);
                model.Note = _noteService.GetAll().Last();
                if (model.Note != null)
                {
                    return Json(Url.Action("Note", "Home", new { id = model.Note.Id }));
                }
            }
            return null;
        }
        [HttpGet]
        public IActionResult DeleteNote(int Id)
        {
            var userId = GetUserID();
            var note = _noteService.GetAll().FirstOrDefault(x => x.Id == Id && x.UserId == userId);
            if (note != null)
            {
                bool isOK = _noteService.Delete(Id);
            }
            var category = _categoryService.Get(note.CategoryId);
            return RedirectToAction("Index", "Home", new { id = category.WorkspaceId });
        }
        [HttpPost]
        public IActionResult CreateCategory(string categoryName)
        {
            var userId = GetUserID();
            int workspaceId = Convert.ToInt32(HttpContext.Session.GetString("WorkspaceId"));
            var workspace = _workspaceService.GetAll(userId).FirstOrDefault(x => x.Id == workspaceId);
            if (workspace != null)
            {
                Category category = new Category();
                category.Name = categoryName;
                category.WorkspaceId = workspace.Id;
                category.UserId = userId;
                _categoryService.Add(category);
            }

            //return RedirectToAction("Index", "Home", new { id = workspace.Id });
            return Json(Url.Action("Index", "Home", new { id = workspace.Id }));
        }
        public IActionResult Settings()
        {
            HomeModel model = new HomeModel();
            var userId = GetUserID();
            model.Workspaces = _workspaceService.GetAll(userId);
            ViewBag.UserId = userId;
            model.Notes = _noteService.GetAllDeleted().FindAll(x => x.UserId == userId);
            return View(model);
        }
        public IActionResult EditWorkspace(int id)
        {
            HomeModel model = new HomeModel();
            var userId = GetUserID();
            ViewBag.UserId = userId;
            var workspace = _workspaceService.GetAll(userId).FirstOrDefault(x => x.Id == id);
            if (workspace != null)
            {
                model.Categories = _workspaceService.GetAllCategory(workspace.Id, userId);
                model.Workspace = workspace;
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult EditCategory(int id, int workspaceId, string categoryName)
        {
            int userId = GetUserID();
            var workspace = _workspaceService.GetAll(userId).FirstOrDefault(x => x.Id == workspaceId);
            if (workspace != null)
            {
                var category = _categoryService.Get(id);
                if (category != null && category.UserId == userId)
                {
                    category.Name = categoryName;
                    _categoryService.Update(category);
                }
            }
            return Json(Url.Action("EditWorkspace", "Home", new { id = workspace.Id }));
        }
        [HttpPost]
        public IActionResult EditWorkspace(int workspaceId, string workspaceName)
        {
            int userId = GetUserID();
            var workspace = _workspaceService.GetAll(userId).FirstOrDefault(x => x.Id == workspaceId);
            if (workspace != null)
            {
                workspace.Name = workspaceName;
                _workspaceService.Update(workspace);
            }
            return Json(Url.Action("EditWorkspace", "Home", new { id = workspace.Id }));
        }
        [HttpPost]
        public IActionResult DeleteWorkspace(int workspaceId)
        {
            int userId = GetUserID();
            ViewBag.UserId = userId;
            var workspace = _workspaceService.GetAll(userId).FirstOrDefault(x => x.Id == workspaceId);
            if (workspace != null)
            {
                _workspaceService.Delete(workspace.Id);
            }
            return Json(Url.Action("Settings", "Home"));

        }
        public IActionResult DeletedWorkspaces()
        {
            HomeModel model = new HomeModel();
            int userId = GetUserID();
            ViewBag.UserId = userId;
            model.Workspaces = _workspaceService.GetAllDeleted(userId).FindAll(x => x.IsDeleted == true);
            return View(model);
        }
        [HttpGet]
        public IActionResult UnDeleteWorkspace(int id)
        {
            int userId = GetUserID();
            var workspace = _workspaceService.GetAllDeleted(userId).FirstOrDefault(x => x.Id == id);
            if (workspace != null)
            {
                if (workspace.IsDeleted == true)
                {
                    workspace.IsDeleted = false;
                    _workspaceService.Update(workspace);
                }
            }
            return RedirectToAction("DeletedWorkspaces", "Home");
        }
        [HttpPost]
        public IActionResult RemoveWorkspace(int workspaceId)
        {
            int userId = GetUserID();
            var workspace = _workspaceService.GetAllDeleted(userId).FirstOrDefault(x => x.Id == workspaceId);
            if (workspace.IsDeleted == true)
            {
                var categories = _workspaceService.GetAllCategory(workspace.Id, userId);
                var notes = _workspaceService.GetAllNote(categories);
                foreach (var item in notes)
                {
                    _noteService.Remove(item.Id);
                }
                foreach (var x in categories)
                {
                    _categoryService.Remove(x.Id);
                }
                bool isOK = _workspaceService.Remove(workspace.Id);
            }
            return Json(Url.Action("DeletedWorkspaces", "Home"));
        }

        [HttpPost]
        public IActionResult DeleteCategory(int categoryId, int workspaceId)
        {
            int userId = GetUserID();
            var workspace = _workspaceService.GetAll(userId).FirstOrDefault(x => x.Id == workspaceId);
            if (workspace != null)
            {
                var category = _categoryService.GetAll().FirstOrDefault(x => x.Id == categoryId && x.WorkspaceId == workspace.Id);
                _categoryService.Delete(category.Id);
            }
            return Json(Url.Action("EditWorkspace", "Home", new { id = workspace.Id }));
        }
        [HttpGet]
        public IActionResult DeletedCategories(int id)
        {
            HomeModel model = new HomeModel();
            var userId = GetUserID();
            var workspace = _workspaceService.GetAllDeleted(userId).FirstOrDefault(x => x.Id == id);
            ViewBag.UserId = userId;
            if (workspace != null)
            {
                model.Categories = _categoryService.GetAllDeleted().FindAll(x => x.WorkspaceId == workspace.Id && x.IsDeleted == true);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult UnDeleteCategory(int id)
        {
            int userId = GetUserID();
            var category = _categoryService.Get(id);
            var workspace = _workspaceService.GetAllDeleted(userId).FirstOrDefault(x => x.Id == category.WorkspaceId);
            if (category != null && category.UserId == userId)
            {
                if (category.IsDeleted == true)
                {
                    category.IsDeleted = false;
                    _categoryService.Update(category);
                }
            }
            return RedirectToAction("DeletedCategories", "Home", new { id = workspace.Id });
        }

        [HttpPost]
        public IActionResult RemoveCategory(int categoryId)
        {
            int userId = GetUserID();
            var category = _categoryService.GetAllDeleted().FirstOrDefault(x => x.Id == categoryId && x.UserId == userId);
            var workspace = _workspaceService.GetAllDeleted(userId).FirstOrDefault(x => x.Id == category.WorkspaceId);
            if (category != null)
            {
                if (category.IsDeleted == true)
                {
                    var notes = _noteService.GetAll().FindAll(x => x.CategoryId == category.Id);
                    foreach (var item in notes)
                    {
                        _noteService.Remove(item.Id);
                    }
                    _categoryService.Remove(category.Id);
                }
            }
            return Json(Url.Action("DeletedCategories", "Home", new { id = workspace.Id }));
        }
        [HttpGet]
        public IActionResult UnDeleteNote(int id)
        {
            int userId = GetUserID();
            var note = _noteService.Get(id);
            if (note != null)
            {
                if (note.IsDeleted == true && note.UserId == userId)
                {
                    note.IsDeleted = false;
                    _noteService.Update(note);
                }
            }
            return RedirectToAction("Settings", "Home");
        }
        [HttpPost]
        public IActionResult CreateWorkspace(string workspaceName)
        {
            var userId = GetUserID();
            Workspace workspace = new Workspace();
            workspace.Name = workspaceName;
            workspace.UserId = userId;
            _workspaceService.Add(workspace);
            workspace = _workspaceService.GetAll(userId).Last();

            return Json(Url.Action("Index", "Home", new { id = workspace.Id }));
        }
        [HttpGet]
        public IActionResult RemoveNote(int id)
        {
            var userId = GetUserID();
            var note = _noteService.Get(id);
            if (note != null && note.UserId == userId)
            {
                _noteService.Remove(id);
            }
            return RedirectToAction("Settings","Home");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
