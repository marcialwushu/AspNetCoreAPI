﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YouLearn.Domain.Arguments.Usuario
{
    public class AutenticarUsuarioRequest
    {
        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
