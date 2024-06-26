namespace PhoneBook.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Country1 { get; set; }
    }

    public class Review
    {
        public int Id { get; set; }
        public Country Country { get; set; }
        public decimal Rating { get; set; }
    }
}