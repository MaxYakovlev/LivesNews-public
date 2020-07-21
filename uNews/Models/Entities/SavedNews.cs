namespace uNews.Models.Entities
{
    public class SavedNews
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public string ImageLink { get; set; }

        public string Description { get; set; }

        public string PublicationDate { get; set; }

        #region Связь с User

        public int UserId { get; set; }

        public User User { get; set; }

        #endregion
    }
}
