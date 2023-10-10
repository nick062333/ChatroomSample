using System.Data;

namespace Adapter
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        
        private IDbTransaction _transaction;

        private bool _disposed = false;

        public IDbConnection Connection => _connection;

        public IDbTransaction Transaction => _transaction;

        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
        }

        public void BeginTransaction()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction?.Commit();
            _transaction = null;
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            _transaction = null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources (e.g., repositories)
                    _transaction?.Dispose();
                    _transaction = null;
                    _connection?.Close();
                }

                // Dispose unmanaged resources here (if any)

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
