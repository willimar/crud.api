using crud.api.register.entities.registers;
using crud.api.register.entities.registers.relational;
using crudi.api.context.config.registers;
using crudi.api.context.config.registers.relational;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace crudi.api.context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) : base(options) 
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AddressConfig().Configure(modelBuilder.Entity<PersonAddress>());
            new CityConfig().Configure(modelBuilder.Entity<City>());
            new CountryConfig().Configure(modelBuilder.Entity<Country>());
            //new DictionaryFieldConfig().Configure(modelBuilder.Entity<DictionaryField>());
            //new DictionaryMessageConfig().Configure(modelBuilder.Entity<DictionaryMessage>());
            new PersonConfig().Configure(modelBuilder.Entity<Person>());
            new ProductConfig().Configure(modelBuilder.Entity<Product>());
            new StateConfig().Configure(modelBuilder.Entity<State>());

            new PersonContactConfig().Configure(modelBuilder.Entity<PersonContact>());
            new PersonDocumentConfig().Configure(modelBuilder.Entity<PersonDocument>());
            new PersonMessageConfig().Configure(modelBuilder.Entity<PersonMessage>());
            new PersonTypeConfig().Configure(modelBuilder.Entity<PersonType>());
            new ProductGroupConfig().Configure(modelBuilder.Entity<ProductGroup>());
            new ProductLogConfig().Configure(modelBuilder.Entity<ProductLog>());
        }
    }
}
