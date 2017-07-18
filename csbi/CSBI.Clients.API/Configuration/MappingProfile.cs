namespace CSBI.Clients.API.Configuration
{
    using Areas.V1.Models;
    using AutoMapper;
    using BLL.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SearchModel, ClientsFilter>();
            CreateMap<Client, ClientModel>()
                .ForMember(destination => destination.FirstName,
                    expression => expression.MapFrom(source => source.FirstName))
                .ForMember(destination => destination.MiddleName,
                    expression => expression.MapFrom(source => source.MiddleName))
                .ForMember(destination => destination.LastName,
                    expression => expression.MapFrom(source => source.LastName))
                .ForMember(destination => destination.Addresses,
                    expression => expression.MapFrom(source => source.Addresses));
        }
    }
}
