using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tamrin1.Entitis;

namespace tamrin1.EntitisMaps
{
    public class PersonEntitsMaps : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.HasMany(_ => _.Books).WithOne(_ => _.Person).HasForeignKey(_ => _.PersonId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
