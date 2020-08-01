using prmToolkit.NotificationPattern;
using System;

namespace YouLearn.Domain.ValueObjects
{
    public class Nome : Notifiable
    {
        public Nome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;

            new AddNotifications<Nome>(this)
                .IfNullOrInvalidLength(x => x.PrimeiroNome, 1, 50, "Primeiro nome é obrigatório e deve conter entre 3 a 50 caracteres");
            new AddNotifications<Nome>(this)
                .IfNullOrInvalidLength(x => x.UltimoNome, 1, 50, "Ultimo nome é obrigatório e deve conter entre 3 a 50 caracteres");

            
        }

        public string PrimeiroNome { get; private set; }

        public string UltimoNome { get; set; }
    }
}
