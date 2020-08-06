using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Services
{
    public class ServiceCanal : Notifiable, IServiceCanal
    {
        public CanalResponse AdicionarCanal(AdicionarCanalRequest request, Guid id)
        {
            Canal canal = new Canal();
            canal.Nome = request.Nome;
            canal.UrlLogo = request.UrlLogo;
            canal.Usuario
        }

        public Arguments.Base.Response ExcluirCanal(Guid idCanal)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CanalResponse> Listar(Guid idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
