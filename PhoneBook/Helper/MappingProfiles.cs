using AutoMapper;
using PhoneBook.Dto;
using PhoneBook.Model;

namespace PhoneBook.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Country, CountryDto>();
        }
    }
}
