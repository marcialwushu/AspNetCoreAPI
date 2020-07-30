using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Arguments.Usuario;

namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServiceUsuario
    {
        AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest request);

        AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest request);

    }
}
