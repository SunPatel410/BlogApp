using System;

namespace BA.Infrastructure.Data.Interfaces.Helpers
{
    public interface IUnitOfWork : IDisposable
    {
        void Complete();
    }
}
