
using Microsoft.EntityFrameworkCore;

namespace Adapter
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext DbContext { get; set; }

        void BeginTransaction();

        void Commit();

        void SaveChanges();

        void Rollback();
    }
}
