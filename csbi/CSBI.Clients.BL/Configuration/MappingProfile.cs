namespace CSBI.Clients.BLL.Configuration
{
    using System.Linq;
    using AutoMapper;
    using DAL.Entities;
    using Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClientEntity, Client>()
                .ForMember(destination => destination.FirstName,
                    expression => expression.MapFrom(source => source.FirstName))
                .ForMember(destination => destination.MiddleName,
                    expression => expression.MapFrom(source => source.MiddleName))
                .ForMember(destination => destination.LastName,
                    expression => expression.MapFrom(source => source.LastName))
                .ForMember(destination => destination.Addresses,
                    expression => expression.MapFrom(source => source.Addresses.Select(x => x.RawAddress).ToList()));
        }
    }
}
