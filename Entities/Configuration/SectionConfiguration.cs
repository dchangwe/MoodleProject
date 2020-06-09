using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Entities.Configuration
{
   public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            
            builder.HasData
                (
                new Section
                {
                    Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                    StartDate = "03/04/2020",
                    EndDate = "12/05/2020",
                    CourseId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                },
                new Section
                {
                    Id = new Guid("7cf612a1-824c-46cd-9067-77f74489216b"),
                    StartDate = "25/05/2020",
                    EndDate ="25/06/2020",
                    CourseId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")

                }
                );

            
        }
    }
}
