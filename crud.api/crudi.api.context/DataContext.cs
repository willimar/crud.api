using crud.api.register.entities.registers;
using crudi.api.context.config.registers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace crudi.api.context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AddressConfig().Configure(modelBuilder.Entity<Address>());
            new CityConfig().Configure(modelBuilder.Entity<City>());
            new CountryConfig().Configure(modelBuilder.Entity<Country>());
            new DictionaryFieldConfig().Configure(modelBuilder.Entity<DictionaryField>());
            new DictionaryMesageConfig().Configure(modelBuilder.Entity<DictionaryMesage>());
            new PersonConfig().Configure(modelBuilder.Entity<Person>());
            new ProductConfig().Configure(modelBuilder.Entity<Product>());
            new StateConfig().Configure(modelBuilder.Entity<State>());
        }
    }
}
