using System.Collections.Generic;

namespace uNews.Models.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        #region Связь с User

        public List<User> Users { get; set; }

        #endregion
    }
}
