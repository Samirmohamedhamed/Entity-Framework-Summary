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
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudId);
            builder.Property(s => s.StudName).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Age).IsRequired();
            builder.HasOne(s => s.Department)
                   .WithMany(d => d.Students)
                   .HasForeignKey(s => s.DepartmentId);

            throw new NotImplementedException();
        }

      
    }
}
