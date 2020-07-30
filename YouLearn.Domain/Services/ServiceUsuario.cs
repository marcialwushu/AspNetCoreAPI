using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Services;

namespace YouLearn.Domain.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        public AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest request)
        {
            if (request==null)
            {
                throw new Exception("Objeto AdicionarUsuarioRequest é obrigatório.");
            }

            Usuario usuario = new Usuario();
            usuario.Nome.PrimeiroNome = "Paulo Rogério";
            usuario.Nome.UltimoNome = "Martins Marques";
            usuario.Email.Endereco = "paulo.analista@outlook.com";
            usuario.Senha = "123456";

            if (usuario.Nome.PrimeiroNome.Length < 3 || usuario.Nome.PrimeiroNome.Length > 50)
            {
                throw new Exception("Primeiro nome é obrigatório e deve conter entre 3 a 50 caracteres");
            }

            if (usuario.Nome.UltimoNome.Length < 3 || usuario.Nome.UltimoNome.Length > 50)
            {
                throw new Exception("Ultimo nome é obrigatório e deve conter entre 3 a 50 caracteres");
            }

            if (usuario.Email.Endereco.IndexOf('@') < 1)
            {
                throw new Exception("Email invalido");
            }
        }

        public AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
