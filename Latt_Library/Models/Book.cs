using System.ComponentModel.DataAnnotations;

namespace Latt_Library.Models
{
    public class Book
    {   
        public int Id { get; set; }
        [StringLength(20, MinimumLength = 2)]
        [Required]
        public string  Name { get; set; }
        [StringLength(30, MinimumLength = 2)]
        [Required]
        public string Author { get; set; }
        [Range(1, 180)]
        [Required]
        public int RentDays { get; set; }
        public bool IsLended { get; set; } = false; 

        public ICollection<Lending>? Lendings { get; set; }
        //public BookLender? Lender { get; set; }
        //public int LenderId { get; set; }

        //public DateTime? RentDaysalDate { get; set; }
        //public DateTime? RentDaysalLenght { get; set; }
        //public bool IsAvailable { get; set; }



    }

}
