using AutoMapper;
using city.core.entities;
using crud.api.core.fieldType;
using crud.api.core.mappers;
using crud.api.dto.Person;
using crud.api.register.entities.registers;
using System;

namespace crud.api.dto.Mapper
{
    public class PersonModelMapper<TUser> : IMapperEntity where TUser : class, new()
    {
        public void Mapper(IMapperConfigurationExpression profile)
        {
            profile.CreateMap<PersonModel, register.entities.registers.Person<TUser>>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.PersonInfo.Name))
                .ForMember(dest => dest.NickName, map => map.MapFrom(src => src.PersonInfo.NickName))
                .ForMember(dest => dest.Birthday, map => map.MapFrom(src => src.PersonInfo.BirthDay))
                .ForMember(dest => dest.Gender, map => map.MapFrom(src => src.PersonInfo.Gender))
                .ForMember(dest => dest.MaritalStatus, map => map.MapFrom(src => src.PersonInfo.MaritalStatus))
                .ForMember(dest => dest.SpecialNeeds, map => map.MapFrom(src => src.PersonInfo.SpecialNeeds))
                .ForMember(dest => dest.Profession, map => map.MapFrom(src => src.PersonInfo.Profession))
                .ForMember(dest => dest.BirthCity, map => map.MapFrom(src => new City() { Id = src.PersonInfo.BirthCity }))
                .ForMember(dest => dest.RegisterDate, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastChangeDate, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Status, map => map.MapFrom(src => RecordStatus.Active))
                .ForMember(dest => dest.User, map => map.MapFrom(src => new TUser()));
        }
    }
}
