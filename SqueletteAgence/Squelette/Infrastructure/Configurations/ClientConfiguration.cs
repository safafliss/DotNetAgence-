using ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasOne(cl => cl.Conseiller)
                .WithMany(co => co.Clients)
                .HasForeignKey(cl => cl.ConseillerFK)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
