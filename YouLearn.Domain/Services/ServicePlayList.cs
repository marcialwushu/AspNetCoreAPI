using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.PlayList;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.ValueObjects;
using Response = YouLearn.Domain.Arguments.Base.Response;

namespace YouLearn.Domain.Services
{
    public class ServicePlayList : Notifiable, IServicePlayList
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryPlayList _repositoryPlayList;

        public ServicePlayList(IRepositoryUsuario repositoryUsuario, IRepositoryPlayList repositoryPlayList)
        {
            _repositoryUsuario = repositoryUsuario;
            _repositoryPlayList = repositoryPlayList;
        }

        public PlayListResponse AdicionarPlayList(AdicionarPlayListRequest request, Guid idUsuario)
        {
            Usuario usuario = _repositoryUsuario.Obter(idUsuario);

            PlayList playList = new PlayList(request.Nome, usuario);

            AddNotifications(playList);

            if (this.IsInvalid()) return null;

            playList = _repositoryPlayList.Adicionar(playList);

            return (PlayListResponse)playList;

        }

        public Arguments.Base.Response ExcluirPlayList(Guid idPlayList)
        {
            //bool existe _repositoryVideo.ExistePlayListAssociada(idPlayList);
            bool existe = false;

            if (existe)
            {
                AddNotification("PlayList", "Não é possivel exvluir uma PlayList associada");
                return null;
            }

            PlayList playList = _repositoryPlayList.Obter(idPlayList);

            if (playList == null)
            {
                AddNotification("PlayList", "Dados não encontrados");
            }

            if (this.IsInvalid()) return null;

            _repositoryPlayList.Excluir(playList);

            return new Response() { Message = "Operação realizada com sucesso" };
        }

        public IEnumerable<PlayListResponse> Listar(Guid idUsuario)
        {
            IEnumerable<PlayList> playListCollection = _repositoryPlayList.Listar(idUsuario);

            var response = playListCollection.ToList().Select(x => (PlayListResponse)x);

            return response;
        }
    }
}
