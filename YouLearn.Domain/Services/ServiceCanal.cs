using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.ValueObjects;
using Response = YouLearn.Domain.Arguments.Base.Response;

namespace YouLearn.Domain.Services
{
    public class ServiceCanal : Notifiable, IServiceCanal
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryCanal _repositoryCanal;

        public ServiceCanal(IRepositoryUsuario repositoryUsuario, IRepositoryCanal repositoryCanal)
        {
            _repositoryUsuario = repositoryUsuario;
            _repositoryCanal = repositoryCanal;
        }

        public CanalResponse AdicionarCanal(AdicionarCanalRequest request, Guid idUsuario)
        {
            Usuario usuario = _repositoryUsuario.Obter(idUsuario);

            Canal canal = new Canal(request.Nome, request.UrlLogo, usuario);

            AddNotifications(canal);

            if (this.IsInvalid()) return null;

            canal = _repositoryCanal.Adicionar(canal);

            return (CanalResponse)canal;
           
            
        }

        public Arguments.Base.Response ExcluirCanal(Guid idCanal)
        {
            //bool existe = _repositoryVideo.ExisteCanalAssociado(idCanal);

            bool existe = true;

            if (existe)
            {
                AddNotification("Canal", "Não foi possivel Excluir um canal associadoa video");

                return null;
            }

            Canal canal = _repositoryCanal.Obter(idCanal);

            if (canal == null)
            {
                AddNotification("Canal", "Dados não encontrado");
            }

            if (IsInvalid()) return null;

            _repositoryCanal.Excluir(canal);

            return new Response() { Message = "Operação realizada com sucesso" };


        }

        public IEnumerable<CanalResponse> Listar(Guid idUsuario)
        {
            IEnumerable<Canal> canalCollection = _repositoryCanal.Listar(idUsuario);

            var response = canalCollection.ToList().Select(entidade => (CanalResponse)entidade);

            return response;
        }
    }
}
