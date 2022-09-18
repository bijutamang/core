using System.Data;

namespace coresystem
{
    public interface IDbConnectionProvider
    {
        IDbConnection GetConnection();
    }
}
