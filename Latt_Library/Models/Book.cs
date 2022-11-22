namespace Latt_Library.Models
{
    public class Book
    {   // 1, Tõde ja Õigus, A.H.Tammsaare, 01.11.21, 15.11.21, available
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime RentalLenght { get; set; }
        public Boolean IsAvailable { get; set; }
    }

}
