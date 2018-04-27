using SpaUserControl.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace SpaUserControl.Infraestructure.Data.Map
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            //Sempre dada uma Entidade de Usuário, ela vai ser salva na Table User
            ToTable("User");
            /* Mapeamento das propriedades */

            /* DatabaseGenerationOption: vai ver que o Id é um Guid e vai gerar esse Guid num formato que o SqlServer entenda */
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            /* No máx 100 caracteres e a propriedade é requerida */
            Property(x => x.Nome).HasMaxLength(100).IsRequired();

            /* Para que não haja email duplicado na minha base, esse código gera um índice unico para o email */
            Property(x => x.Email).HasMaxLength(160).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("IX_EMAIL", 1) { IsUnique = true })).IsRequired();

            /* 32 porque a senha encriptada vai ter 32 caracteres */
            Property(x => x.Senha).HasMaxLength(32).IsFixedLength();
        }
    }
}
