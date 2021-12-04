using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sda.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sda.EntityFrameworkCore.EntityMapper
{
    public class HREntityMapper:IEntityTypeConfiguration<HREntity>
    {
        public void Configure(EntityTypeBuilder<HREntity> builder)
        {
            builder.ToTable("HREntitys");

            builder.HasKey(x => x.Id);
        }
    }
}
