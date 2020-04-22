using crud.api.core.eceptions;
using crud.api.register.entities.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace crud.api.test.entities.registers
{
    public class AddressTest
    {
        private City _city = new City() { Id = Guid.NewGuid() };

        [Fact]
        public void EmpityFiedTest()
        {
            var validators = new Address().Validate();

            Assert.True(validators.Count(c => c.MessageType.Equals(nameof(FieldValueException))) == 10);
        }

        [Fact]
        public void EqualsIdTest()
        {
            var id = Guid.NewGuid();
            var val1 = new Address() { Id = id };
            var val2 = new Address() { Id = id };

            Assert.Equal(val1, val2);
        }

        [Fact]
        public void EqualsInstanceTest()
        {
            var val1 = new Address();

            Assert.Equal(val1, val1);
        }

        [Fact]
        public void EqualsFieldsTest()
        {
            var val1 = new Address() { Id = Guid.NewGuid(), City = _city, Number = "NUMBERTESTE", Neighborhood = "BAIRRO DE TESTE", StreetName = "NOME DA RUA" };
            var val2 = new Address() { Id = Guid.NewGuid(), City = _city, Number = "NUMBERTESTE", Neighborhood = "BAIRRO DE TESTE", StreetName = "NOME DA RUA" };

            Assert.Equal(val1, val2);
        }

        [Fact]
        public void EqualsPostalCodeTest()
        {
            var val1 = new Address() { Id = Guid.NewGuid(), PostalCode = "POSTAL CODE TESTE" };
            var val2 = new Address() { Id = Guid.NewGuid(), PostalCode = "POSTAL CODE TESTE" };

            Assert.Equal(val1, val2);
        }
    }
}
