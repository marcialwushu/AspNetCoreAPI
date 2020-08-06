using System;
using YouLearn.Domain.Entities.Base;

namespace YouLearn.Domain.Entities
{
    public class Canal : EntityBase
    {
        public Canal(string nome, string urlLogo, Usuario usuario)
        {
            Nome = nome;
            UrlLogo = urlLogo;
            Usuario = usuario;
        }

        public string Nome { get; set; }

        public string UrlLogo { get; set; }

        public Usuario Usuario { get; set; }
    }
}
