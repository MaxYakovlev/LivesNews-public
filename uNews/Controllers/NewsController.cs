using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using uNews.Models;
using uNews.RSS;
using uNews.ViewModels;
using AutoMapper;
using uNews.Parsing;
using Microsoft.AspNetCore.Authorization;
using uNews.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using uNews.Currency;
using uNews.Security;
using System;

namespace uNews.Controllers
{
    public class NewsController : Controller
    {
        private readonly VedomostiRss vedomostiRss;

        private readonly VedomostiParsing vedomostiParsing;

        private readonly CurrencyCBR currencyCBR;

        private readonly IMapper mapper;

        private readonly ApplicationContext context;

        public NewsController(VedomostiRss vedomostiRss, VedomostiParsing vedomostiParsing, CurrencyCBR currencyCBR, IMapper mapper, ApplicationContext context)
        {
            this.vedomostiRss = vedomostiRss;
            this.mapper = mapper;
            this.vedomostiParsing = vedomostiParsing;
            this.currencyCBR = currencyCBR;
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string url = "/news", string category = "Все новости")
        {
            List<News> news = await vedomostiRss.GetNewsAsync(url);

            List<CurrencyItem> currencyItems = await currencyCBR.GetCurrenciesAsync();

            List<CurrencyItem> topCurrencies = currencyItems.Where(c => c.CharCode == "USD" || c.CharCode == "EUR").ToList();

            currencyItems.RemoveAll(c => c.CharCode == "USD" || c.CharCode == "EUR");

            NewsCurrenciesViewModel newsCurrenciesViewModel = new NewsCurrenciesViewModel()
            {
                News = news,
                CurrencyItems = currencyItems,
                TopCurrencies = topCurrencies
            };

            ViewBag.Category = category;

            return View(newsCurrenciesViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> OneNews(OneNews oneNews)
        {
            OneNewsViewModel oneNewsViewModel = await vedomostiParsing.GetOneNews(oneNews, mapper);

            return View(oneNewsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOneNews(OneNews oneNews)
        {
            if (!User.Identity.IsAuthenticated) return BadRequest(new { Message = "Авторизируйтесь" });

            if (ModelState.IsValid)
            {
                User user = await context.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);

                SavedNews savedNews = mapper.Map<SavedNews>(oneNews);

                savedNews.User = user;

                savedNews.UserId = user.Id;

                SavedNews exsistedSavedNews = await context.SavedNews.FirstOrDefaultAsync(n => n.Title == oneNews.Title && n.UserId == user.Id);

                if(exsistedSavedNews == null)
                {
                    await context.SavedNews.AddAsync(savedNews);

                    await context.SaveChangesAsync();

                    return Ok(new { Message = "Сохранено" });
                }
                else
                {
                    return BadRequest(new { Message = "Уже сохраненно" });
                }
            }

            return BadRequest(new { Message = "Ошибка" });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> SavedNews()
        {
            User user = await context.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);

            List<SavedNews> savedNews = context.SavedNews.Where(s => s.UserId == user.Id).ToList();

            savedNews.Sort((x, y) => y.Id.CompareTo(x.Id));

            return View(savedNews);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOneNews(int id)
        {
            if (!User.Identity.IsAuthenticated) return BadRequest();

            SavedNews savedNews = await context.SavedNews.FirstOrDefaultAsync(n => n.Id == id);

            if(savedNews == null)
            {
                return BadRequest();
            }

            context.SavedNews.Remove(savedNews);

            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
