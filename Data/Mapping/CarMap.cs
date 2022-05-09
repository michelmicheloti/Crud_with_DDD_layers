using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entity;

namespace Data.Mapping
{
    public class CarMap : IEntityTypeConfiguration<CarEntity>
    {
        public void Configure(EntityTypeBuilder<CarEntity> builder)
        {
            builder.ToTable("Car");

            builder.HasKey(Car => Car.Id);

            builder.HasIndex(Car => Car.Cor);

            builder.Property(Car => Car.Cor)
                    .IsRequired()
                    .HasMaxLength(20);

            builder.HasIndex(Car => Car.Marca);

            builder.Property(Car => Car.Marca)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.HasIndex(Car => Car.Modelo);

            builder.Property(Car => Car.Modelo)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.HasIndex(Car => Car.Placa);

            builder.Property(Car => Car.Placa)
                    .IsRequired()
                    .HasMaxLength(10);
        }
    }
}
