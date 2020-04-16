using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace crudi.api.context.config
{
    public class BaseConfig<TEntity> where TEntity : class
    {
        protected const string VARCHAR = "varchar";
        protected const string UNIQUEIDENTIFIER = "UNIQUEIDENTIFIER";
        protected const string DATETIME = "DATETIME";

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey("Id");
            builder.Property("RegisterDate").IsRequired().HasColumnType(DATETIME);
            builder.Property("LastChangeDate").IsRequired().HasColumnType(DATETIME);
            builder.Property("Status").IsRequired();
        }
    }
}
