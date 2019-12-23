using AutoMapper;
using Library.API.Entities;
using Library.API.Helpers;
using Library.API.Models;

namespace Library.API.Services
{
    public interface IAutoMapperConfig
    {
        IMapper Mapper { get; set; }
    }
    public class AutoMapperConfig : IAutoMapperConfig
    {
        public IMapper Mapper { get; set; }

        public AutoMapperConfig()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));

                cfg.CreateMap<Book, BookDto>();
            });

            Mapper = config.CreateMapper();
        }
    }
}
