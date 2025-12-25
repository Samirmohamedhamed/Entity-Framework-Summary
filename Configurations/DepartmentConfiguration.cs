using EntityFrameWorkCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkCodeFirst.Configurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(e=>e.DepartmentId);
            builder.Property(e => e.DepartmentName).IsRequired().HasMaxLength(50);
            builder.HasMany(e => e.Students)
                   .WithOne(s => s.Department)
                   .HasForeignKey(s => s.DepartmentId);
            throw new NotImplementedException();
        }
    }
}
