using SpaUserControl.Domain.Models;
using System;

namespace SpaUserControl.Domain.Contratos.Repositorios
{
    public interface IUserRepository : IDisposable
    {
        // Retornar o usuário por Email
        User Get(string email);
        User Get(Guid id);
        void Criar(User user);
        void Atualizar(User user);
        void Apagar(User user);
    }
}
