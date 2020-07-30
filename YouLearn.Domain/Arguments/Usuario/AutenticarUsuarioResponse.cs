using System;
using System.Collections.Generic;
using System.Text;

namespace YouLearn.Domain.Arguments.Usuario
{
    public class AutenticarUsuarioResponse
    {
        public Guid Id { get; set; }

        public string PrimeiroNome { get; set; }

        public string UltimoNome { get; set; }
    }
}
