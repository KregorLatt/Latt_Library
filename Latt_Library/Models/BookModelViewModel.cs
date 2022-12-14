using Microsoft.AspNetCore.Mvc.Rendering;

namespace Latt_Library.Models
{
    public class BookModelViewModel
    {
        public int Id { get; set; }
        public List<Book> Books { get; set; }
        public SelectList Name { get; set; }
        public string Author { get; set; }
        public string BookName { get; set; }
        public string SearchString { get; set; }
    }
}
