using AutoMapper;
using city.core.entities;
using crud.api.core.fieldType;
using crud.api.core.mappers;
using crud.api.dto.Person;
using crud.api.register.entities.registers;
using System;

namespace crud.api.Mapper
{
    //public class PersonModelMapper : IMapperEntity
    //{
    //    public void Mapper(IMapperConfigurationExpression profile)
    //    {
    //        profile.CreateMap<PersonInfoModel, Person>()
    //            .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
    //            .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
    //            .ForMember(dest => dest.NickName, map => map.MapFrom(src => src.NickName))
    //            .ForMember(dest => dest.Birthday, map => map.MapFrom(src => src.BirthDay))
    //            .ForMember(dest => dest.Gender, map => map.MapFrom(src => src.Gender))
    //            .ForMember(dest => dest.MaritalStatus, map => map.MapFrom(src => src.MaritalStatus))
    //            .ForMember(dest => dest.SpecialNeeds, map => map.MapFrom(src => src.SpecialNeeds))
    //            .ForMember(dest => dest.Profession, map => map.MapFrom(src => src.Profession))
    //            .ForMember(dest => dest.BirthCity, map => map.MapFrom(src => new City() { Id = src.BirthCity }))
    //            .ForMember(dest => dest.RegisterDate, map => map.MapFrom(src => DateTime.UtcNow))
    //            .ForMember(dest => dest.LastChangeDate, map => map.MapFrom(src => DateTime.UtcNow))
    //            .ForMember(dest => dest.Status, map => map.MapFrom(src => RecordStatus.Active));
    //    }
    //}

    //public class PersonMapper : IMapperEntity
    //{
    //    public void Mapper(IMapperConfigurationExpression profile)
    //    {
    //        profile.CreateMap<Person, Person>()
    //            .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
    //            .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
    //            .ForMember(dest => dest.NickName, map => map.MapFrom(src => src.NickName))
    //            .ForMember(dest => dest.Birthday, map => map.MapFrom(src => src.Birthday))
    //            .ForMember(dest => dest.Gender, map => map.MapFrom(src => src.Gender))
    //            .ForMember(dest => dest.MaritalStatus, map => map.MapFrom(src => src.MaritalStatus))
    //            .ForMember(dest => dest.SpecialNeeds, map => map.MapFrom(src => src.SpecialNeeds))
    //            .ForMember(dest => dest.Profession, map => map.MapFrom(src => src.Profession))
    //            .ForMember(dest => dest.LastChangeDate, map => map.MapFrom(src => DateTime.UtcNow));
    //    }
    //}

    //public class UserModelMapper : IMapperEntity
    //{
    //    public void Mapper(IMapperConfigurationExpression profile)
    //    {
    //        profile.CreateMap<UserModel, Person>()
    //            .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
    //            .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
    //            .ForMember(dest => dest.NickName, map => map.MapFrom(src => src.NickName))
    //            .ForMember(dest => dest.Birthday, map => map.MapFrom(src => src.BirthDay))
    //            .ForMember(dest => dest.Gender, map => map.MapFrom(src => src.Gender))
    //            .ForMember(dest => dest.MaritalStatus, map => map.MapFrom(src => src.MaritalStatus))
    //            .ForMember(dest => dest.SpecialNeeds, map => map.MapFrom(src => src.SpecialNeeds))
    //            .ForMember(dest => dest.Profession, map => map.MapFrom(src => src.Profession))
    //            .ForMember(dest => dest.BirthCity, map => map.MapFrom(src => new City() { Id = src.BirthCity }))
    //            .ForMember(dest => dest.RegisterDate, map => map.MapFrom(src => DateTime.UtcNow))
    //            .ForMember(dest => dest.LastChangeDate, map => map.MapFrom(src => DateTime.UtcNow))
    //            .ForMember(dest => dest.Status, map => map.MapFrom(src => RecordStatus.Active))
    //            .ForMember(dest => dest.User, map => map.MapFrom(src => new User()
    //            {
    //                Id = Guid.NewGuid(),
    //                LastChangeDate = DateTime.UtcNow,
    //                RegisterDate = DateTime.UtcNow,
    //                Status = RecordStatus.Active,
    //                UserEmail = src.UserEmail,
    //                UserName = src.UserName,
    //                UserPassword = src.UserPassword
    //            }));
    //    }
    //}
}
