using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
   public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = new Guid ("80abbca8-664d-4b20-b5de-024705497d4a"),
                    FirstName = "Dana",
                    LastName = "Changwe",
                    Email = "danachangwe@gmail.com",
                    Password = "263vvqh"
                },
                new User
                {
                    Id = new Guid ("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    FirstName = "Patrick",
                    LastName = "Harris",
                    Email = "pharris@gmail.com",
                    Password = "36yqnsuw"
                   
                }
                );
            }
        }
    }

