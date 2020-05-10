using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.core.mappers
{
    public interface IMapperEntity
    {
        void Mapper(IMapperConfigurationExpression profile);
    }
}
