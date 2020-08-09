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
        public AdicionarVideoResponse AddicionarVideo(AdicionarVideoRequest request, Guid idUsuario)
        {
            if(request == null)
            {
                AddNotification("AdicionarVideoRequest", "O Objeto AdicionarVideoRequest é Obrigatório");
                return null;
            }

            Usuario usuario = _repositoryUsuario.Obter(idUsuario);
        }

        public IEnumerable<VideoResponse> Listar(string tags)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VideoResponse> Listar(Guid idPlayList)
        {
            throw new NotImplementedException();
        }
    }
}
