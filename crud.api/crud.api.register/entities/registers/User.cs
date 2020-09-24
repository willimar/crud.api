using crud.api.core.entities;

namespace crud.api.register.entities.registers
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
    }
}