using ApiDotNet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet6.Infra.Data.Maps
{
    public class PersonMaps : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Pessoa");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .HasColumnName("IdPessoa")
                   .UseIdentityColumn();
            builder.Property(x => x.Document)
                   .HasColumnName("Documento")
                   .HasMaxLength(20);
            builder.Property(x => x.Name)
                   .HasColumnType("Nome")
                   .HasMaxLength(100);
            builder.Property(x => x.Phone)
                   .HasColumnName("Celular")
                   .HasMaxLength(20);
            builder.HasMany(x => x.Purchases)
                   .WithOne(p => p.Person)
                   .HasForeignKey(c=> c.PersonId);

        }
    }
}
