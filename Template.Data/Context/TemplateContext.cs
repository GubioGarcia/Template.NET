using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Extentions;
using Template.Data.Mappings;
using Template.Domain.Entities;

namespace Template.Data.Context
{
    public class TemplateContext: DbContext
    {
        public TemplateContext(DbContextOptions<TemplateContext> option)
            : base(option) { }

        #region

        public DbSet<User> Users { get; set; }

        #endregion

        // sobrescreve o método de mesma assinatura na classe DbContext
        // recebe parâmetro do tipo "ModelBuilder", usado para construi o modelo de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ApplyConfiguration: aplica a configuração especificada pela classe UserMap ao modelo de dados
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.ApplyGlobalConfigurations();
            modelBuilder.SeedData();

            // garante que as configurações padrão da classe base sejam aplicadas juntamente com as configurações personalizadas
            base.OnModelCreating(modelBuilder);
        }
    }
}
