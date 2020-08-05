using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Interfaces.Services.Base;

namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServiceUsuario : IServiceBase
    {
        AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest request);

        AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest request);

    }
}
