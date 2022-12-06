namespace Latt_Library.Models
{
    public class Lending
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? DateCompleted  { get; set; }
        public bool IsLended { get; set; }
    }
}
