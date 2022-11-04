using ComiComi.Models;

namespace ComiComi.Data.ViewModel
{
    public class ComicDropDownVM
    {
        public ComicDropDownVM()
        {
            Authors = new List<Author>();
            Artists = new List<Artist>();
            Publishers = new List<Publisher>();
        }
        public List<Author> Authors { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Publisher> Publishers { get; set; }
    }
}
