using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Services
{
    public class ServiceUsuario : Notifiable, IServiceUsuario
    {
        public AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest request)
        {
            if (request==null)
            {
                AddNotification("AdicionarUsuarioRequest", "Objeto AdicionarUsuarioRequest é obrigatório.");
                return null;
            }

            //Cria entidade
            Nome nome = new Nome(request.PrimeiroNome, request.UltimoNome);

            nome.PrimeiroNome = "joao";
            //nome.UltimoNome = ;

            AddNotifications(nome);

            Email email = new Email(request.Email);
            email.Endereco = "1234";

            Usuario usuario = new Usuario();
            usuario.Nome = nome;
            usuario.Email = email;
            usuario.Senha = request.Senha;

            

            if (usuario.Senha.Length >= 3)
            {
                throw new Exception("Senha deve ter no minimo 3 caracteres");
            }

            //Persiste no banco de dados 
            //AdicionarUsuarioResponse response =  new RepositoryUsuario().Salvar(usuario);

            //return response;

            return new AdicionarUsuarioResponse(Guid.NewGuid());
        }

        public AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
