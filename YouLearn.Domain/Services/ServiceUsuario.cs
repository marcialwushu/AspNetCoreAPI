using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Services
{
    public class ServiceUsuario : Notifiable, IServiceUsuario
    {
        //Dependências do serviço
        private readonly IRepositoryUsuario _repositoryUsuario;

        //Construtor
        public ServiceUsuario(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest request)
        {
            if (request == null)
            {
                AddNotification("AdicionarUsuarioRequest", "Objeto AdicionarUsuarioRequest é obrigatório.");
                return null;
            }

            //Cria value objects
            Nome nome = new Nome(request.PrimeiroNome, request.UltimoNome);

                      
            Email email = new Email(request.Email);
            

            Usuario usuario = new Usuario(nome, email, request.Senha);
           

            AddNotifications(usuario);

            
            if (this.IsInvalid()) return null;

            //persistir no banco de dados 
            _repositoryUsuario.Salvar(usuario);

            return new AdicionarUsuarioResponse(usuario.Id);
        }

        public AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest request)
        {
            if (request == null)
            {
                AddNotification("AutenticarUsuarioRequest", "Objeto Obrigatório");
                return null;
            }

            var email = new Email(request.Email);
            var usuario = new Usuario(email, request.Senha);

            AddNotifications(usuario);

            if (this.IsInvalid()) return null;

            usuario = _repositoryUsuario.Obter(usuario.Email.Endereco, usuario.Senha);

            if (usuario == null)
            {
                AddNotification("Usuario", "Dados não encontrados");
                return null;
            }

            

            var response = (AutenticarUsuarioResponse)usuario;

            return response;
        }
    }
}
