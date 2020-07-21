using System;

namespace uNews.ViewModels
{
    public class UserAdminViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool IsLocked { get; set; }
    }
}
