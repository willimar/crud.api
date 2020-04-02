using crud.api.core.eceptions;
using crud.api.register.entities.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace crud.api.test.entities.registers
{
    public class ProductTest
    {
        [Fact]
        public void EmpityFiedTest()
        {
            var validators = new Product().Validate();

            Assert.True(validators.Count(c => c.MesageType.Equals(nameof(FieldValueException))) == 5);
        }

        [Fact]
        public void EqualsIdTest()
        {
            var id = Guid.NewGuid();
            var val1 = new Product() { Id = id };
            var val2 = new Product() { Id = id };

            Assert.Equal(val1, val2);
        }

        [Fact]
        public void EqualsInstanceTest()
        {
            var val1 = new Product();

            Assert.Equal(val1, val1);
        }

        [Fact]
        public void EqualsFieldsTest()
        {
            var val1 = new Product() { Id = Guid.NewGuid(), Name = "NOME DA RUA" };
            var val2 = new Product() { Id = Guid.NewGuid(), Name = "NOME DA RUA" };

            Assert.Equal(val1, val2);
        }

        [Fact]
        public void EqualsInternalCodeTest()
        {
            var val1 = new Product() { Id = Guid.NewGuid(), InternalCode = "123" };
            var val2 = new Product() { Id = Guid.NewGuid(), InternalCode = "123" };

            Assert.Equal(val1, val2);
        }

        [Fact]
        public void EqualsExternalCodeTest()
        {
            var val1 = new Product() { Id = Guid.NewGuid(), OfficialCode = "123" };
            var val2 = new Product() { Id = Guid.NewGuid(), OfficialCode = "123" };

            Assert.Equal(val1, val2);
        }
    }
}
