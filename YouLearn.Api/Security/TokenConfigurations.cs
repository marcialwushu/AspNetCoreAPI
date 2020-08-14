using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouLearn.Api.Security
{
    public class TokenConfigurations
    {
        public bool Audience { get; set; }

        public bool Issuer { get; set; }

        public int Seconds { get; set; }
    }
}
