using AspDotNetCoreWebApi.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspDotNetCoreWebApi.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id); // Id yi primary key yap.
            builder.Property(x => x.Id).UseIdentityColumn(); // Id yi birer birer artan şekilde ayarla

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200); // name not null ve max length 200 karakter

            builder.Property(x => x.Stock).IsRequired();

            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal (18,2)"); //toplam 18 karakter olsun virgülden sonra da 2 karakter olabilir

            builder.Property(x => x.InnerBarcode).HasMaxLength(50);

            //IsDeleted ı yapmadık çünkü bool default false atanıyor Category de eklenmedi entity frameowk category tablosu ile bağlıycak

            builder.ToTable("Products"); // tablonun ismi bu şekilde yaratılacak
        }
    }
}
