using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PresenileNotes.Entity.model;
using PresenileNotes.Infrastructure;
using PresenileNotes.Service;
using Microsoft.AspNetCore.Http;
using PresenileNotes.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace PresenileNotes.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IRepository<User> _userRepository;
        readonly UserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        [ActivatorUtilitiesConstructor]
        public AuthController(IRepository<User> userRepository, IHttpContextAccessor httpContextAccessor)
        {
            this._userRepository = userRepository;
            _userService = new UserService(_userRepository);
            _httpContextAccessor = httpContextAccessor;
        }
        public int GetUserID()
        {
            var email = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            var user = _userService.GetAll().FirstOrDefault(x => x.Email == email);
            return user.Id;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(HomeModel model)
        {
            if (ModelState.IsValid)
            {
                if (_userService.Login(model.User.Email, model.User.Password))
                {
                    var claims = new List<Claim>
                    { new Claim(ClaimTypes.Email, model.User.Email) };
                    //claims.Add(new Claim(ClaimTypes.Role,model.User.Role));
                    var userIdentiy = new ClaimsIdentity(claims, model.User.Email);
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentiy);
                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }
        [Authorize]
        [HttpGet]
        public IActionResult AddUser()
        {
            var userId = GetUserID();
            var user = _userService.Get(userId);
            if (user.Role == "Admin")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddUser(HomeModel model)
        {

            var userId = GetUserID();
            var user = _userService.Get(userId);
            if (user.Role == "Admin")
            {
                if (model != null)
                {
                    var userEmail = _userService.GetAll().FindAll(x => x.Email == model.User.Email);
                    if (userEmail.Count == 0)
                    {
                        bool isOK = _userService.Add(model.User);
                        if (isOK)
                        {
                            ViewBag.Success = "user has been created.";
                            ModelState.Clear();
                        }
                    }
                    else
                    {
                        ViewBag.Message = "this email address is used!";
                        model.User = null;
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Users()
        {
            HomeModel model = new HomeModel();
            var userId = GetUserID();
            var user = _userService.Get(userId);
            ViewBag.UserId = userId;
            if (user.Role == "Admin")
            {
                model.Users = _userService.GetAllDeleted();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            HomeModel model = new HomeModel();
            var userId = GetUserID();
            var user = _userService.Get(userId);
            if (user.Role == "Admin")
            {
                model.User = _userService.Get(id);
                if (model.User != null)
                {
                    _userService.Delete(id);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Users", "Auth");
        }
        [Authorize]
        [HttpGet]
        public IActionResult UnDelete(int id)
        {
            HomeModel model = new HomeModel();
            var userId = GetUserID();
            var user = _userService.Get(userId);
            if (user.Role == "Admin")
            {
                model.User = _userService.Get(id);
                if (model.User != null)
                {
                    model.User.IsDeleted = false;
                    _userService.Update(model.User);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Users", "Auth");
        }
        [Authorize]
        [HttpGet]
        public IActionResult EditProfile()
        {
            HomeModel model = new HomeModel();
            var userId = GetUserID();
            model.User = _userService.Get(userId);
            ViewBag.UserId = userId;
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public IActionResult EditProfile(HomeModel model)
        {
            var userId = GetUserID();
            var user = _userService.Get(userId);
            if (model.User.Id == userId)
            {
                if (model.User.Role != "Admin")
                {
                    user.FirstName = model.User.FirstName;
                    user.LastName = model.User.LastName;
                    user.Email = model.User.Email;
                    _userService.Update(user);
                    ViewBag.Success = "Yout profile has been updated.";
                }
                else
                {
                    user.FirstName = model.User.FirstName;
                    user.LastName = model.User.LastName;
                    user.Email = model.User.Email;
                    user.Role = model.User.Role;
                    _userService.Update(user);
                    ViewBag.Success = "Yout profile has been updated.";
                }
                return View(model);
            }
            ViewBag.Message = "something went wrong.";
            return View(model);
            
        }
        [Authorize]
        [HttpPost]
        public IActionResult ChangePassword(string oldPassword,string newPassword)
        {
            var userId = GetUserID();
            var user = _userService.Get(userId);
            if (_userService.GetPasswordHash(oldPassword) == user.Password)
            {
                user.Password = newPassword;
               return Json(_userService.UpdatePassword(user));
            }
            return Json(false);
        }

    }
}
