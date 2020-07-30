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

            //Cria entidade
            Usuario usuario = new Usuario();
            usuario.Nome.PrimeiroNome = "Paulo Rogério";
            usuario.Nome.UltimoNome = "Martins Marques";
            usuario.Email.Endereco = "paulo.analista@outlook.com";
            usuario.Senha = "123456";

            //Validações
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

            if (usuario.Senha.Length >= 3)
            {
                throw new Exception("Senha deve ter no minimo 3 caracteres");
            }

            //Persiste no banco de dados 
            AdicionarUsuarioResponse response =  new RepositoryUsuario().Salvar(usuario);

            return response;
        }

        public AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
