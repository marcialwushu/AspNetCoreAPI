using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public Nome Nome { get; set; }

        public Email Email { get; set; }

        public string Senha { get; set; }
    }
}
