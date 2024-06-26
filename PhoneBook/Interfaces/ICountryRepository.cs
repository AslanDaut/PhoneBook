using PhoneBook.Model;

namespace PhoneBook.Interfaces
{
    public interface ICountryRepository
    {
        bool CountryExists(int countId);
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountry(string name);
        decimal GetCountryRating(int countId);
    }
}