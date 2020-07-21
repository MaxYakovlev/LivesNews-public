using AutoMapper;
using System;
using System.Collections.Generic;
using uNews.Models;
using uNews.Models.Entities;
using uNews.ViewModels;

namespace uNews.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<OneNews, OneNewsViewModel>().ConstructUsing(n => new OneNewsViewModel()
            {
                Title = n.Title,
                Author = n.Author,
                Description = n.Description,
                Date = n.Date,
                Category = n.Category,
                ImageLink = n.ImageLink,
                Link = n.Url,
                HtmlElements = new List<HtmlElement>()
            });

            CreateMap<RegisterViewModel, User>().ConstructUsing(u => new User()
            {
                Email = u.Email,
                RegistrationDate = DateTime.Now,
                IsLocked = false
            });

            CreateMap<OneNews, SavedNews>().ConstructUsing(s => new SavedNews()
            {
                Title = s.Title,
                Link = s.Url,
                Author = s.Author,
                Category = s.Category,
                ImageLink = s.ImageLink,
                Description = s.Description,
                PublicationDate = s.Date
            });

            CreateMap<User, UserAdminViewModel>().ConstructUsing(u => new UserAdminViewModel()
            {
                Id = u.Id,
                Email = u.Email,
                IsLocked = u.IsLocked,
                RegistrationDate = u.RegistrationDate
            });
        }
    }
}
