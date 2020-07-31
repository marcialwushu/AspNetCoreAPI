using System;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Services;

namespace YouLearn.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AdicionarUsuarioRequest request = new AdicionarUsuarioRequest()
            {
                Email = "paulo.analista@outlook.com",
                PrimeiroNome = "Paulo Rogério",
                UltimoNome = "Martins Marques",
                Senha = "12"
            };

            var response = new ServiceUsuario().AdicionarUsuario(request);

            Console.ReadKey();
        }
    }
}
