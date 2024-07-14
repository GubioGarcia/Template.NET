using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;

namespace Template.Data.Extentions
{
    public static class ModelBuilderExtentions
    {
        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = Guid.Parse("09ac9fd2-5b00-4d22-8884-4d988a04182b"),
                        Name = "User Default",
                        Email = "userdefault@template.com",
                        DateCreated = new DateTime(2020,1,1),
                        IsDeleted = false,
                        DateUpdated = null
                    }
                );

            return builder;
        }
    }
}
