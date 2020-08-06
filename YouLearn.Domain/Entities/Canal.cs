using prmToolkit.NotificationPattern;
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

            new AddNotifications<Canal>(this)
                .IfNullOrInvalidLength(x => x.Nome, 2, 50, "Obrigatório e deve conter  entre 2 a 50 caracteres")
                .IfNullOrInvalidLength(x => x.UrlLogo, 4, 200, "Obrigatório e deve conter  entre 4 a 200 caracteres");

            AddNotifications(usuario);
        }

        public string Nome { get; private set; }

        public string UrlLogo { get; private set; }

        public Usuario Usuario { get; private set; }
    }
}
