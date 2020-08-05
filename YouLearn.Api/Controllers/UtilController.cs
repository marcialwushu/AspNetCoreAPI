using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouLearn.Api.Controllers
{
    public class UtilController
    {
        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "Seja bem vindo ao YouLearn";
        }

        [HttpGet]
        [Route("Versao")]
        public string Versao()
        {
            return "0.0.1";
        }

        //[HttpPost]
        //[Route("")]
        //public string Post()
        //{
        //    return "Post - inserir nova informação";
        //}

        //[HttpPut]
        //[Route("")]
        //public string Put()
        //{
        //    return "Put - Atualizar informação";
        //}

        //[HttpDelete]
        //[Route("")]
        //public string Delete()
        //{
        //    return "Delete - Exclui informação";
        //}
    }
}
