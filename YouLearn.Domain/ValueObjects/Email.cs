using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace YouLearn.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string endereco)
        {
            Endereco = endereco;

            new AddNotifications<Email>(this)
                .IfNotEmail(x => x.Endereco, "Email invalido");


            if (Endereco.IndexOf('@') < 1)
            {
                throw new Exception("Email invalido");
            }
        }

        public string Endereco { get; set; }
    }
}
