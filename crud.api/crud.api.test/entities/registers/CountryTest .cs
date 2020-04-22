using crud.api.core.eceptions;
using crud.api.register.entities.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace crud.api.test.entities.registers
{
    public class CountryTest
    {
        [Fact]
        public void EmpityFiedTest()
        {
            var validators = new Country().Validate();

            Assert.True(validators.Count(c => c.MessageType.Equals(nameof(FieldValueException))) == 6);
        }

        [Fact]
        public void EqualsIdTest()
        {
            var id = Guid.NewGuid();
            var val1 = new Country() { Id = id };
            var val2 = new Country() { Id = id };

            Assert.Equal(val1, val2);
        }

        [Fact]
        public void EqualsInstanceTest()
        {
            var val1 = new Country();

            Assert.Equal(val1, val1);
        }

        [Fact]
        public void EqualsFieldsTest()
        {
            var val1 = new Country() { Id = Guid.NewGuid(), Name = "NOME DA RUA" };
            var val2 = new Country() { Id = Guid.NewGuid(), Name = "NOME DA RUA" };

            Assert.Equal(val1, val2);
        }

        [Fact]
        public void EqualsCityCodeTest()
        {
            var val1 = new Country() { Id = Guid.NewGuid(), CountryCode = 123 };
            var val2 = new Country() { Id = Guid.NewGuid(), CountryCode = 123 };

            Assert.Equal(val1, val2);
        }
    }
}
