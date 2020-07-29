using System;
using System.Collections.Generic;
using System.Text;

namespace YouLearn.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public virtual Guid Id { get; set; }
    }
}
