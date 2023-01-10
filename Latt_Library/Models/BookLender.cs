using Latt_Library.Controllers;
using System.ComponentModel.DataAnnotations;

namespace Latt_Library.Models
{
    public class BookLender
    {
        public int Id { get; set; }
        [StringLength(10, MinimumLength = 2)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(10, MinimumLength = 2)]
        [Required]
        public string LastName { get; set; }
        
        public string  ssId { get; set; }

        public ICollection<Lending>? Lendings { get; set; }
    }
}
