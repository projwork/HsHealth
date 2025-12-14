using System.Data;

namespace PatientMenu.Api.Interface
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
