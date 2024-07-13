using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;

namespace Template.Data.Mappings
{
    // define a configuração de mapeamento para a entidade User para a tabela do DB
    public class UserMap: IEntityTypeConfiguration<User>
    {

        //  Configure: método obrigátorio
        //  recebe objeto EntityTypeBuilder<User> que permite configurar propriedades da entidade User
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        }
    }
}
