using Latt_Library.Controllers;

namespace Latt_Library.Models
{
    public class BookLender
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  ssId { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
