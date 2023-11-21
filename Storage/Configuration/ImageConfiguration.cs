using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Configuration
{
    internal class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable(nameof(Image));
            builder.HasKey(nameof(Image.ImageId));
            builder.Property(t => t.ImageId).ValueGeneratedOnAdd();
            builder.Property(t => t.FileName).IsRequired().HasMaxLength(100);
            builder.Property(t => t.ImageFormat).IsRequired().HasMaxLength(10);
        }
    }
}
