
namespace TC_WinForms.Models
{
    public class TechnologicalProcces
    {
        public string Id { get; set; }
        public string Article { get; set; }
        public string Name { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();
        public string Description { get; set; }
        public string Version { get; set; } = "1.0";
        public string DateCreation { get; set; } = DateTime.Now.ToString("dd.MM.yyyy");
        public List<TechnologicalCard> TechnologicalCards { get; set; } = new List<TechnologicalCard>();

        public class Author 
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }

        }
    }
}
