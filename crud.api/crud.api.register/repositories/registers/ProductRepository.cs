using crud.api.core.repositories;
using crud.api.register.entities.registers;
using data.provider.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.register.repositories.registers
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(IDataProvider provider) : base(provider)
        {
        }
    }
}
