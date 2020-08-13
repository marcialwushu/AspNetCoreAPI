using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Infra.Transactions;

namespace YouLearn.Api.Controllers
{
    public class CanalController : Base.ControllerBase
    {
        private readonly IServiceUsuario _serviceUsuario;

        private readonly IServiceCanal _serviceCanal;

        public CanalController(IServiceCanal serviceCanal, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _serviceCanal = serviceCanal;
        }

        public CanalController(IServiceUsuario serviceUsuario, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _serviceUsuario = serviceUsuario;
        }

        [HttpGet]
        [Route("api/v1/Canal/Listar")]
        public IActionResult Listar()
        {
            try
            {
                Guid idUsuario = Guid.NewGuid();

                var response = _serviceCanal.Listar(idUsuario);

                return ResponseAsync(response, _serviceCanal);
            }
            catch (Exception ex)
            {

                return ResponseExceptionAsync(ex);
            }
        }


        [HttpPost]
        [Route("api/v1/Canal/Adicionar")]
        public IActionResult Adicionar([FromBody]AdicionarCanalRequest request)
        {
            try
            {
                Guid idUsuario = Guid.NewGuid();

                var response = _serviceCanal.AdicionarCanal(request, idUsuario);

                return ResponseAsync(response, _serviceCanal);

            }
            catch (Exception ex)
            {

                return ResponseExceptionAsync(ex);
            }
        }

        [HttpDelete]
        [Route("api/v1/Canal/Excluir/{id:Guid}")]
        public IActionResult Excluir(Guid idCanal)
        {
            try
            {
                var response = _serviceCanal.ExcluirCanal(idCanal);

                return ResponseAsync(response, _serviceCanal);
            }
            catch (Exception ex)
            {

                return ResponseExceptionAsync(ex);
            }
        }
    }
}
