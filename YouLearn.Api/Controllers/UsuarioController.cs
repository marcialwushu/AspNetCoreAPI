using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Infra.Transactions;

namespace YouLearn.Api.Controllers
{
    public class UsuarioController : Base.ControllerBase
    {
        private readonly IServiceUsuario _serviceUsuario;

        public UsuarioController(IUnitOfWork unitOfWork, IServiceUsuario serviceUsuario) : base(unitOfWork)
        {
            _serviceUsuario = serviceUsuario;
        }

        [HttpPost]
        [Route("api/v1/Usuario/Adicionar")]
        public IActionResult Adicionar([FromBody]AdicionarUsuarioRequest request)
        {
            try
            {
                var response = _serviceUsuario.AdicionarUsuario(request);
                return  ResponseAsync(response, _serviceUsuario);
            }
            catch (Exception ex)
            {
                return  ResponseExceptionAsync(ex);
            }


        }
    }
}
