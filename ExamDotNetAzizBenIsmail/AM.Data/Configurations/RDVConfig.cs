using AM.Core.Domain;
using ExamDotNetAzizBenIsmail;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data.Configurations
{
    public class RDVConfig : IEntityTypeConfiguration<RDV>
    {


        public void Configure(EntityTypeBuilder<RDV> builder)
        {
            builder.HasOne(r => r.MyClient)
                    .WithMany(c => c.RDVs)
                    .HasForeignKey(r => r.ClientFK)
                    .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(r => r.MyPrestation)
                    .WithMany(f => f.RDVs)
                    .HasForeignKey(r => r.PrestationFK)
                    .OnDelete(DeleteBehavior.Cascade);
            builder.HasKey(r => new { r.ClientFK, r.PrestationFK, r.DateRDV });
        }
    }
}
