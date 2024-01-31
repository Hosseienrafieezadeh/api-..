using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tamrin1.Entitis;

namespace tamrin1.EntitisMaps
{
    public class BookEntitsMaps : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(_ => _.Id);

            builder
           .HasOne(_ => _.Person)
           .WithMany(_ => _.Books)
           .HasForeignKey(_ => _.PersonId)
           .HasPrincipalKey(_ => _.Id)
           .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
