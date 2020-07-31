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

            //Validações
            if (PrimeiroNome.Length < 3 || PrimeiroNome.Length > 50)
            {
                throw new Exception("Primeiro nome é obrigatório e deve conter entre 3 a 50 caracteres");
            }

            if (UltimoNome.Length < 3 || UltimoNome.Length > 50)
            {
                throw new Exception("Ultimo nome é obrigatório e deve conter entre 3 a 50 caracteres");
            }
        }

        public string PrimeiroNome { get; set; }

        public string UltimoNome { get; set; }
    }
}
