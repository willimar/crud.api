﻿using crud.api.core.eceptions;
using crud.api.register.entities.registers;
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

            Assert.True(validators.Count(c => c.MesageType.Equals(nameof(FieldValueException))) == 6);
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
            var doc = new DictionaryField() { Id = Guid.NewGuid() };

            var val1 = new Person() { Id = Guid.NewGuid(), Documents = new List<DictionaryField>() { doc } };
            var val2 = new Person() { Id = Guid.NewGuid(), Documents = new List<DictionaryField>() { doc } };

            Assert.Equal(val1, val2);
        }
    }
}