using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Entities.Configuration
{
   public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasData
                (
                new Enrollment
                {
                    Id = new Guid("c4c987d5-4254-47da-9f55-3da2f6d7f078"),
                    SectionId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                    UserId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a")
                },
                new Enrollment
                {
                    Id = new Guid("e2708e39-c561-4708-9167-48579b3cd0ff"),
                    //SectionId = new Guid("7cf612a1-824c-46cd-9067-77f74489216b"),
                    SectionId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                    UserId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a")
                }
                );
                

            
        }
    }
}
