using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using uNews.Models;
using uNews.Models.Entities;
using uNews.ViewModels;

namespace uNews.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationContext context;

        private readonly IMapper mapper;

        public AdminController(ApplicationContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<User> users = context.Users.ToList();

            List<UserAdminViewModel> usersAdminViewModel = mapper.Map<List<UserAdminViewModel>>(users);

            return View(usersAdminViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> LockUser(int id)
        {
            User user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if(user != null)
            {
                user.IsLocked = true;

                context.Users.Update(user);

                await context.SaveChangesAsync();

                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> UnlockUser(int id)
        {
            User user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user != null)
            {
                user.IsLocked = false;

                context.Users.Update(user);

                await context.SaveChangesAsync();

                return Ok();
            }

            return BadRequest();
        }
    }
}
