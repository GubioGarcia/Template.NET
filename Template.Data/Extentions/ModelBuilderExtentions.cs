using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;
using Template.Domain.Models;

namespace Template.Data.Extentions
{
    public static class ModelBuilderExtentions
    {
        // aplica configurações globais a todas as entidades do modelo
        public static ModelBuilder ApplyGlobalConfigurations(this ModelBuilder builder)
        {
            // itera por todos os tipos de entidade no modelo
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                // itera por todas as propriedades do tipo de entidade atual
                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(Entity.Id):
                            property.IsKey();
                            break;
                        case nameof(Entity.DateUpdated):
                            property.IsNullable = true;
                            break;
                        case nameof(Entity.DateCreated):
                            property.IsNullable = false;
                            property.SetDefaultValue(DateTime.Now);
                            break;
                        case nameof(Entity.IsDeleted):
                            property.IsNullable = false;
                            property.SetDefaultValue(false);
                            break;
                        default:
                            break;
                    }
                }
            }

            return builder;
        }

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
