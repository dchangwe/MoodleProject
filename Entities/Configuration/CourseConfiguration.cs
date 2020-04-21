using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
   public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData
                (
                new Course
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    CourseName = "WebAPI and Intermediate C#",
                    Description = "This course teaches students to develop RESTful Web Service API using C# .Net Core"
                },
                new Course
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    CourseName = "Introduction to C#",
                    Description = "learning object oriented programming"
                }
                );
        }
    }
}
