using SpaUserControl.Domain.Contratos.Repositorios;
using SpaUserControl.Domain.Models;
using SpaUserControl.Infraestructure.Data;
using System;
using System.Linq;

namespace SpaUserControl.Infraestructure.Repositorios
{
    public class UserRepository : IUserRepository
    {
        /* Foi criada uma nova instancia porque eu vou precisar trabalhar com
         os meus usuários aqui dentro desse contexto */
        private AppDataContext _context = new AppDataContext();

        #region Interface
        public User Get(string email)
        {
            /* FirstOrDefault = se o objeto não existir, ele retorna nulo */
            return _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }
        public User Get(Guid id)
        {
            /* Quando é feito _context.Users é feita uma instância do DBSet da classe AppContext
             * Vai estar vinculado com a tabela User do banco de dados através do UserMap*/
            return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Criar(User user)
        {
            _context.Users.Add(user);
            /* SaveChanges vai persistir no banco */
            _context.SaveChanges();
        }
        public void Atualizar(User user)
        {
            /* Pegar o estado do objeto  - automaticamente ele vai fazer as alterações
             e persisti-las no banco */
            _context.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
        public void Apagar(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public void Dispose()
        {
            /* Garantir que a conexão vai ser fechada aqui - 
             * toda vez que eu usar o meu repositório, ele vai passar pelo 
             método dispose e vai fechar aqui */
            _context.Dispose();
        }
        #endregion
    }
    
}
