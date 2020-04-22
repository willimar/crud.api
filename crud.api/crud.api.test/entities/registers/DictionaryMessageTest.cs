using crud.api.core.eceptions;
using crud.api.register.entities.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace crud.api.test.entities.registers
{
    public class DictionaryMessageTest
    {
        [Fact]
        public void EmpityFiedTest()
        {
            var validators = new DictionaryMessage().Validate();

            Assert.True(validators.Count(c => c.MessageType.Equals(nameof(FieldValueException))) == 6);
        }

        [Fact]
        public void EqualsIdTest()
        {
            var id = Guid.NewGuid();
            var val1 = new DictionaryMessage() { Id = id };
            var val2 = new DictionaryMessage() { Id = id };

            Assert.Equal(val1, val2);
        }

        [Fact]
        public void EqualsInstanceTest()
        {
            var val1 = new DictionaryMessage();

            Assert.Equal(val1, val1);
        }

        [Fact]
        public void EqualsFieldsTest()
        {
            var val1 = new DictionaryMessage() { Id = Guid.NewGuid(), Value = "NOME DA RUA", Type = "TYPE TESTE" };
            var val2 = new DictionaryMessage() { Id = Guid.NewGuid(), Value = "NOME DA RUA", Type = "TYPE TESTE" };

            Assert.Equal(val1, val2);
        }
    }
}
