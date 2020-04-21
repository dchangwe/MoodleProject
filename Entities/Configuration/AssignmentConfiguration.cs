using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
  public  class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasData(
                new Assignment
                {
                    Id = new Guid("77a56797-c2f3-47cb-aa17-f940a61f5ae7"),
                    AssignmentName = "Project setup",
                    Description = "create a  new web API project and configure it to the project",
                    CourseId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                new Assignment
                {
                    Id = new Guid("2d7ebe4b-d62f-4d09-b37c-9081609dc025"),
                    AssignmentName = "Configuring a logging service",
                    Description = "add a logging service to the project",
                    CourseId =  new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                }
                );
        }
    }
}
