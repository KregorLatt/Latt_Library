namespace Latt_Library.Models
{
    public class Book
    {   
        public int Id { get; set; }

        public BookLender Lender { get; set; }
        public int LenderId { get; set; }
        public string Author { get; set; }
        
        public DateTime? RentalDate { get; set; }
        public DateTime? RentalLenght { get; set; }
        public bool IsAvailable { get; set; }

        

    }

}
