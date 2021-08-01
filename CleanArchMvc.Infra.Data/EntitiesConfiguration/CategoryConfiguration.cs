using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    //this class is used for aplying migrations correctly,

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Id will be the Primary Key
            builder.HasKey(t => t.Id);
            //Name will Have 100 Characters max and will not accept null as value.
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            //Populating Table with data 
            builder.HasData(
                new Category(1, "Material Escolar"),
                new Category(2, "Eletrônicos"),
                new Category(3, "Acessórios")
                );

        }
    }
}
