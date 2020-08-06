using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouLearn.Domain.Interfaces.Services.Base;
using YouLearn.Infra.Transactions;

namespace YouLearn.Api.Controllers.Base
{
    public class ControllerBase : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IServiceBase _serviceBase;

        public ControllerBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public new IActionResult ResponseAsync(object result, IServiceBase serviceBase)
        {
            _serviceBase = serviceBase;

            if (!serviceBase.Notifications.Any())
            {
                try
                {
                    _unitOfWork.Commit();

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest($"houve um problema interno com o servidor.Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                }
            }
            else
            {
                return BadRequest(new { errors = serviceBase.Notifications });
            }


        }
        public IActionResult ResponseExceptionAsync(Exception ex)
        {
            return BadRequest(new { errors = ex.Message, exception = ex.ToString() });
        }

        protected override void Dispose(bool disposing)
        {
            if (_serviceBase != null)
            {
                _serviceBase.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
