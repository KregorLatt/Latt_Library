using System.ComponentModel.DataAnnotations;

namespace Latt_Library.Models
{
    public class Lending
    {
        public int Id { get; set; }
        public BookLender Lender { get; set; }
        public int BookLenderId { get; set; }
        public Book LentBook { get; set; }
        public int BookId { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? DateCompleted  { get; set; }

    }
}
