using AutoMapper;
using crud.api.core.fieldType;
using crud.api.core.mappers;
using crud.api.Model.Registers;
using crud.api.register.entities.registers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.api.Mapper
{
    public class PersonModelMapper : IMapperEntity
    {
        public void Mapper(IMapperConfigurationExpression profile)
        {
            profile.CreateMap<PersonModel, Person>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.NickName, map => map.MapFrom(src => src.NickName))
                .ForMember(dest => dest.Birthday, map => map.MapFrom(src => src.BirthDay))
                .ForMember(dest => dest.Gender, map => map.MapFrom(src => src.Gender))
                .ForMember(dest => dest.MaritalStatus, map => map.MapFrom(src => src.MaritalStatus))
                .ForMember(dest => dest.SpecialNeeds, map => map.MapFrom(src => src.SpecialNeeds))
                .ForMember(dest => dest.Profession, map => map.MapFrom(src => src.Profession))
                .ForMember(dest => dest.BirthCity, map => map.MapFrom(src => new City() { Id = src.BirthCity }))
                .ForMember(dest => dest.RegisterDate, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastChangeDate, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Status, map => map.MapFrom(src => RecordStatus.Active));
        }
    }

    public class PersonMapper : IMapperEntity
    {
        public void Mapper(IMapperConfigurationExpression profile)
        {
            profile.CreateMap<Person, Person>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.NickName, map => map.MapFrom(src => src.NickName))
                .ForMember(dest => dest.Birthday, map => map.MapFrom(src => src.Birthday))
                .ForMember(dest => dest.Gender, map => map.MapFrom(src => src.Gender))
                .ForMember(dest => dest.MaritalStatus, map => map.MapFrom(src => src.MaritalStatus))
                .ForMember(dest => dest.SpecialNeeds, map => map.MapFrom(src => src.SpecialNeeds))
                .ForMember(dest => dest.Profession, map => map.MapFrom(src => src.Profession))
                .ForMember(dest => dest.LastChangeDate, map => map.MapFrom(src => DateTime.UtcNow));
        }
    }
}
