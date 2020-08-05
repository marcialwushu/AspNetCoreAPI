using System;
using System.Collections.Generic;
using System.Text;

namespace YouLearn.Infra.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
