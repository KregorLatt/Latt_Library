using System;
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
        public DateTime? DateCompleted { get; set; }


        public string GetRowColor()
        {
            DateTime current = DateTime.Now;
            DateTime expiry = DateEnd ?? current;


            var duration = ((expiry - current).Days);
            if (duration <0)
            {
                return "red";
            }
            else if (duration <7)
            {
                return "yellow";
            }
            else 
            {
                
                return "green";
                

            }
        }
    }
}


