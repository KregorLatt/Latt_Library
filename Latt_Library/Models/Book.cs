namespace Latt_Library.Models
{
    public class Book
    {   
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Author { get; set; }
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
