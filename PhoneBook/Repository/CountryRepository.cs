using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhoneBook.Interfaces;
using PhoneBook.Model;

namespace PhoneBook.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CountryExists(int countId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Country.OrderBy(p => p.Id).ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Country.FirstOrDefault(p => p.Id == id);
        }

        public Country GetCountry(string name)
        {
            return _context.Country.FirstOrDefault(p => p.Country1 == name);
        }

        public decimal GetCountryRating(int countId)
        {
            var reviews = _context.Reviews.Where(review => review.Country.Id == countId);
            if (!reviews.Any())
                return 0;
            return reviews.Average(r => r.Rating);
        }
    }
}