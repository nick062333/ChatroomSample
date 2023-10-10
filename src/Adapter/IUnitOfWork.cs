using System.Data;

namespace Adapter
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }

        IDbTransaction Transaction { get; }

        public void BeginTransaction();
        
        public void Commit();
        
        public void Rollback();
    }
}
