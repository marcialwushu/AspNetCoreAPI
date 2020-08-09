using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Arguments.Video;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.ValueObjects;
using Response = YouLearn.Domain.Arguments.Base.Response;

namespace YouLearn.Domain.Services
{
    public class ServiceVideo : Notifiable, IServiceVideo
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryCanal _repositoryCanal;
        private readonly IRepositoryPlayList _repositoryPlayList;
        private readonly IRepositoryVideo _repositoryVideo;

        public ServiceVideo(IRepositoryUsuario repositoryUsuario, IRepositoryCanal repositoryCanal, IRepositoryPlayList repositoryPlayList, IRepositoryVideo repositoryVideo)
        {
            _repositoryUsuario = repositoryUsuario;
            _repositoryCanal = repositoryCanal;
            _repositoryPlayList = repositoryPlayList;
            _repositoryVideo = repositoryVideo;
        }

        public AdicionarVideoResponse AddicionarVideo(AdicionarVideoRequest request, Guid idUsuario)
        {
            if(request == null)
            {
                AddNotification("AdicionarVideoRequest", "O Objeto AdicionarVideoRequest é Obrigatório");
                return null;
            }

            Usuario usuario = _repositoryUsuario.Obter(idUsuario);
            if(usuario == null)
            {
                AddNotification("Usuario", "Usuario não informado");
                return null;
            }

            Canal canal = _repositoryCanal.Obter(request.IdCanal);
            if(canal == null)
            {
                AddNotification("Canal", "Canal não informado");
                return null;
            }

            PlayList playList = null;
            if(request.IdPlayList != Guid.Empty)
            {
                playList = _repositoryPlayList.Obter(request.IdPlayList);
                if(playList == null)
                {
                    AddNotification("PlayList", "Playlist não informada");
                    return null;
                }
            }

            var video = new Video(canal, playList, request.Titulo, request.Descricao, request.Tags, request.OrdemNaPlayList, request.IdVideoYoutube);

            AddNotifications(video);

            if (this.IsInvalid())
            {
                return null;
            }

            _repositoryVideo.Adicionar(video);

            return new AdicionarVideoResponse(video.Id);
        }

        public IEnumerable<VideoResponse> Listar(string tags)
        {
            IEnumerable<Video> videoCollection = _repositoryVideo.Listar(tags);

            var response = videoCollection.ToList().Select(entidade => (VideoResponse)entidade);
        }

        public IEnumerable<VideoResponse> Listar(Guid idPlayList)
        {
            throw new NotImplementedException();
        }
    }
}
