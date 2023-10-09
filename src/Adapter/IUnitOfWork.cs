namespace Adapter
{
    public interface IUnitOfWork : IDisposable
    {
        public void BeginTransaction();
        
        public void Commit();
        
        public void Rollback();
    }
}
