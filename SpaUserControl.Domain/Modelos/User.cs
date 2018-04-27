using SpaUserControl.Common.Resources;
using SpaUserControl.Common.Validation;
using System;

namespace SpaUserControl.Domain.Models
{
    public class User
    {
        #region Propriedades
        public Guid Id { get; private set; }
        public String Nome { get; private set; }
        public String Email { get; private set; }
        public String Senha { get; private set; }
        #endregion

        #region Construtor
        public User(String nome, String email)
        {
            this.Id = Guid.NewGuid();
            this.Nome = nome;
            this.Email = email;
            //this.Senha = senha;
        }
        protected User() {}
        #endregion

        #region Metodos
        public void setSenha(String senha, String confirmaSenha)
        {

            AssertionConcern.AssertArgumentNotNull(senha, Errors.senhaInvalida);
            AssertionConcern.AssertArgumentNotNull(confirmaSenha, Errors.confimacaoSenhaInvalida);
            AssertionConcern.AssertArgumentEquals(senha, confirmaSenha, Errors.senhaInvalida);
            AssertionConcern.AssertArgumentLength(senha, 6, 20, Errors.senhaInvalida);

            this.Senha = SenhaAssertionConcern.Encrypt(senha);
        }

        public String ResetSenha()
        {
            string senha = Guid.NewGuid().ToString().Substring(0, 8);
            this.Senha = SenhaAssertionConcern.Encrypt(senha);
            return senha;
        }

        public void AlterarNome(String nome)
        {
            this.Nome = nome;
        }

        public void Validar()
        {
            AssertionConcern.AssertArgumentNotNull(this.Nome, Errors.nomeUsuarioInvalido);
            AssertionConcern.AssertArgumentLength(this.Nome, 3, 50, Errors.nomeUsuarioInvalido);
            EmailAssertionConcern.AssertIsValid(this.Email);
            SenhaAssertionConcern.AssertIsValid(this.Senha);
        }
        #endregion
    }
}
