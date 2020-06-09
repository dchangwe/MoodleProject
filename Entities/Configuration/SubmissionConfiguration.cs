using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Entities.Configuration
{
   public class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {
            builder.HasData
                (
                 new Submission
                 {
                     Id = new Guid("f069b2ff-c17e-404c-ae78-bd9cfec1adf2"),
                     Score = "3.0",
                     Submission_Comment = "you did good on the assignment",
                     UserId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                     AssignmentId = new Guid("87a56797-c2f3-47cb-aa17-f940a61f5ae7"),
                     SectionId = new Guid ("7cf612a1-824c-46cd-9067-77f74489216b")
                     
                 },
                 new Submission
                 {
                     Id = new Guid("23f77b75-70be-4059-a6a7-62b5f522ef9e"),
                     Score = "1.0",
                     Submission_Comment = "you did not complete the assignment",
                     UserId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                     AssignmentId = new Guid("3d7ebe4b-d62f-4d09-b37c-9081609dc025"),
                     SectionId = new Guid ("7cf612a1-824c-46cd-9067-77f74489216b")
                 }

                );
        }
    }
}
