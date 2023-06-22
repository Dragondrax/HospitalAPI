using Hospital.Application.API.Data.EntitiesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Hospital.Application.API.Data.Mapping
{
    public class RegisterMedicalRecordEntitieMapping : IEntityTypeConfiguration<RegisterMedicalRecordEntitie>
    {
        public void Configure(EntityTypeBuilder<RegisterMedicalRecordEntitie> builder)
        {
            builder.HasIndex(x => x.CPF);

            builder.Property(p => p.FullName).HasMaxLength(250);
            builder.Property(p => p.Endereco).HasMaxLength(500);
            builder.Property(p => p.Celular).HasMaxLength(14);
            builder.Property(p => p.CPF).HasMaxLength(11);
        }
    }
}
