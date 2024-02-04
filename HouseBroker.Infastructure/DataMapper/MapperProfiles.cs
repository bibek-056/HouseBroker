using AutoMapper;
using HouseBroker.Core.DTOs.PropertyDTOs;
using HouseBroker.Core.Models;

namespace HouseBroker.Infastructure.DataMapper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles() 
        {
            CreateMap<Property, PropertyReadDTO>();
            CreateMap<PropertyCreateDTO, Property>();
            CreateMap<PropertyUpdateDTO, Property>();
            CreateMap<Property, PropertyUpdateDTO>();
        }
    }
}
