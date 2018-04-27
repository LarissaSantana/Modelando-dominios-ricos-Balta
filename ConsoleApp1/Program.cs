using SpaUserControl.Domain.Models;
using System;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var user = new User("Larissa", "larissa@hotmail.com");
            try
            {
                user.setSenha("0", "123456");
                user.Validar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            /* Nome não pode ser setado em razão do private set
            user.Nome = "Larissa";
            */
            Console.WriteLine(user.Nome);
            Console.WriteLine(user.Senha);
            string senha = user.ResetSenha();
            Console.WriteLine(senha);
            Console.WriteLine(user.Senha);
            Console.ReadKey();
        }
    }
}
