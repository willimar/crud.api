using city.core.entities;
using crud.api.core.exceptions;
using crud.api.register.entities.registers;
using crud.api.register.entities.registers.relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace crud.api.test.entities.registers
{
    public class PersonTest
    {
        [Fact]
        public void EmpityFiedTest()
        {
            var validators = new Person().Validate();

            Assert.True(validators.Count(c => c.MessageType.Equals(nameof(FieldValueException))) == 11);
        }

        [Fact]
        public void EqualsIdTest()
        {
            var id = Guid.NewGuid();
            var val1 = new Person() { Id = id };
            var val2 = new Person() { Id = id };

            Assert.Equal(val1, val2);
        }

        [Fact]
        public void EqualsInstanceTest()
        {
            var val1 = new Person();

            Assert.Equal(val1, val1);
        }

        [Fact]
        public void EqualsFieldsTest()
        {
            var name = "Nome para teste";
            var birthday = DateTime.UtcNow;
            var birthCity = new City() { Id = Guid.NewGuid() };
            var gender = "TESTA TUDO";

            var val1 = new Person() { Id = Guid.NewGuid(), Name = name, Birthday = birthday, BirthCity = birthCity, Gender = gender };
            var val2 = new Person() { Id = Guid.NewGuid(), Name = name, Birthday = birthday, BirthCity = birthCity, Gender = gender };

            Assert.Equal(val1, val2);
        }

        [Fact]
        public void EqualsDocumentFieldTest()
        {
            var doc = new PersonDocument() { Id = Guid.NewGuid() };

            var val1 = new Person() { Id = Guid.NewGuid(), Documents = new List<PersonDocument>() { doc } };
            var val2 = new Person() { Id = Guid.NewGuid(), Documents = new List<PersonDocument>() { doc } };

            Assert.Equal(val1, val2);
        }
    }
}
