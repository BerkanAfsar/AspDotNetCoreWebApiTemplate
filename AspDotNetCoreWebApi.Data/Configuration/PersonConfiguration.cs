using AspDotNetCoreWebApi.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspDotNetCoreWebApi.Data.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id); 
            builder.Property(x => x.Id).UseIdentityColumn(); 

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Surname).IsRequired().HasMaxLength(200);
        }
    }
}
