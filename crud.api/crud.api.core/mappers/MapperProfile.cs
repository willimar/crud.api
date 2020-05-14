using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.core.mappers
{
    public class MapperProfile<TEntityFrom, TEntityTo> : Profile where TEntityFrom : class where TEntityTo : class
    {
        private readonly IMapperEntity _mapperEntity;

        public MapperProfile(IMapperEntity mapperEntity)
        {
            this._mapperEntity = mapperEntity;
        }

        public TEntityTo Map(TEntityFrom from)
        {
            var config = new MapperConfiguration(cfg => {
                this._mapperEntity.Mapper(cfg);
            });

            var mapper = config.CreateMapper();

            return mapper.Map<TEntityFrom, TEntityTo>(from);
        }

        public TEntityTo Map(TEntityFrom newValue, TEntityTo oldValue)
        {
            var config = new MapperConfiguration(cfg => {
                this._mapperEntity.Mapper(cfg);
            });

            var mapper = config.CreateMapper();

            return mapper.Map<TEntityFrom, TEntityTo>(newValue, oldValue);
        }
    }
}
