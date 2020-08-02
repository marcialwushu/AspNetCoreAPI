using System;
using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.Enums;

namespace YouLearn.Domain.Entities
{
    public class PlayList : EntityBase
    {
        public string Nome { get; private set; }

        public Usuario Usuario { get; private set; }

        public EnumStatus Status { get; private set; }
    }
}
