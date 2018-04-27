using SpaUserControl.Domain.Models;
using SpaUserControl.Infraestructure.Data.Map;
using System.Data.Entity;

namespace SpaUserControl.Infraestructure.Data
{
    public class AppDataContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public AppDataContext() : base("AppConnectionString")
        {
            /* O LazyLoading carrega os dados por partes -
             Se o programador não solicitar a carga, o relacionamento entre entidades não será recuperado
             */
            Configuration.LazyLoadingEnabled = false;
            /* JSON não serializa Proxy, só o objeto concreto, então é melhor deixar ele desabilitado */
            Configuration.ProxyCreationEnabled = false;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
        }

    }   
}
