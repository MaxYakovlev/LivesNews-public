using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using uNews.Models;
using uNews.Models.Entities;
using uNews.Security;
using uNews.Validation;
using uNews.ViewModels;

namespace uNews.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationContext context;

        private readonly IMapper mapper;

        private readonly ValidationService validationService;

        public AccountController(ApplicationContext context, IMapper mapper, ValidationService validationService)
        {
            this.context = context;
            this.mapper = mapper;
            this.validationService = validationService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "News");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid && !User.Identity.IsAuthenticated)
            {
                if (!validationService.IsEmailValid(model.Email))
                {
                    ModelState.AddModelError("Invalid email", "Некорректный email");

                    return View(model);
                }

                if (!validationService.IsPasswordValid(model.Password))
                {
                    ModelState.AddModelError("Invalid password", "Пароль должен состоять из латинского алфавита");

                    return View(model);
                }

                User user = await context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

                Role role = await context.Roles.FirstOrDefaultAsync(u => u.Name == "user");

                if (user == null)
                {
                    string encryptedPassword = Cryptography.EncryptPassword(model.Password);

                    user = mapper.Map<User>(model);

                    user.Password = encryptedPassword;

                    user.RoleId = role.Id;

                    user.Role = role;

                    await context.Users.AddAsync(user);

                    int resultOfSave = await context.SaveChangesAsync();

                    if (resultOfSave > 0)
                    {
                        await Authenticate(user, model.RememberMe);

                        return RedirectToAction("Index", "News");
                    }
                    else
                    {
                        ModelState.AddModelError("Error adding to DB", "Ошибка с БД, повторите попытку позже");
                    }

                }
                else
                {
                    ModelState.AddModelError("Email already registered", "Email уже зарегестрирован");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "News");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid && !User.Identity.IsAuthenticated)
            {
                string encryptedPassword = Cryptography.EncryptPassword(model.Password);

                User user = await context.Users
                    .Include(r => r.Role)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == encryptedPassword);

                if(user != null && !user.IsLocked)
                {
                    await Authenticate(user, model.RememberMe);

                    return RedirectToAction("Index", "News");
                }
                else if (user != null && user.IsLocked)
                {
                    ModelState.AddModelError("User is locked", "Ваш аккаунт заблокирован");
                }
                else
                {
                    ModelState.AddModelError("User not found", "Неверный email или пароль");
                }
            }

            return View(model);
        }

        private async Task Authenticate(User user, bool rememberMe)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            int days = rememberMe ? 14 : 1;

            AuthenticationProperties authenticationProperties = new AuthenticationProperties()
            {
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddDays(days)
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id), authenticationProperties);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "News");
        }
    }
}
