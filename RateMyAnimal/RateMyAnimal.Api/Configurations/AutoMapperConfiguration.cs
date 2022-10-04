using AutoMapper;
using RateMyAnimal.Api.ViewModels;
using RateMyAnimal.Domain.Entities;
using RateMyAnimal.Domain.Responses;

namespace RateMyAnimal.Api.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<string, byte[]>().ConvertUsing<Base64Converter>();
            CreateMap<byte[], string>().ConvertUsing<Base64Converter>();

            #region Animal
            CreateMap<CommonResponse<Animal>, CommonResponse<AnimalViewModel>>().ReverseMap();
            CreateMap<CommonResponse<IEnumerable<Animal>>, CommonResponse<IEnumerable<AnimalViewModel>>>().ReverseMap();

            CreateMap<Animal, AnimalViewModel>()
                .ForMember(a => a.Id, o => o.MapFrom(r => r.Id))
                .ForMember(a => a.Date, o => o.MapFrom(r => r.Date))
                .ForMember(a => a.Categories, o => o.MapFrom(r => r.AnimalCategories))
                .ForMember(a => a.Image, o => o.MapFrom(r => r.Image));

            CreateMap<AnimalViewModel, Animal>()
                .ForMember(a => a.Id, o => o.MapFrom(r => r.Id))
                .ForMember(a => a.Date, o => o.MapFrom(r => DateTime.Now))
                .ForPath(a => a.AnimalCategories, o => o.MapFrom(r => r.Categories))
                .ForMember(a => a.Image, o => o.MapFrom(r => r.Image));
            #endregion

            #region AnimalCategory
            CreateMap<AnimalCategory, AnimalCategoryViewModel>().ReverseMap();
            #endregion

            #region Category
            CreateMap<CommonResponse<Category>, CommonResponse<CategoryViewModel>>().ReverseMap();
            CreateMap<CommonResponse<IEnumerable<Category>>, CommonResponse<IEnumerable<CategoryViewModel>>>().ReverseMap();

            CreateMap<Category, CategoryViewModel>()
                .ForMember(a => a.Id, o => o.MapFrom(r => r.Id))
                .ForMember(a => a.Description, o => o.MapFrom(r => r.Description))
                .ForMember(a => a.Animals, o => o.MapFrom(r => r.AnimalCategories))
                .ReverseMap();
            #endregion
        }

        private class Base64Converter : ITypeConverter<string, byte[]>, ITypeConverter<byte[], string>
        {
            public byte[] Convert(string source, byte[] destination, ResolutionContext context)
                => System.Convert.FromBase64String(source);

            public string Convert(byte[] source, string destination, ResolutionContext context)
                => System.Convert.ToBase64String(source);
        }
    }
}
