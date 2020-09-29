using crud.api.core.repositories;
using crud.api.core.services;
using crud.api.register.entities.registers;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.register.services.registers
{
    public class PersonService<TUser> : BaseService<Person<TUser>> where TUser : class
    {
        public PersonService(IRepository<Person<TUser>> repository) : base(repository)
        {
        }
    }
}
