using System;
using System.Collections.Generic;

namespace uNews.Models.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool IsLocked { get; set; }

        #region Связь с SavedNews

        public List<SavedNews> SavedNews { get; set; }

        #endregion

        #region Связь с Role

        public int RoleId { get; set; }

        public Role Role { get; set; }

        #endregion
    }
}
