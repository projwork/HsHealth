using Dapper;
using PatientMenu.Api.Interface;
using PatientMenu.Api.Models;

namespace PatientMenu.Api.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public PatientRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Patient?> GetAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Patient>(
                "SELECT * FROM Patients WHERE Id = @Id", new { Id = id });
        }

        public async Task<IEnumerable<MenuItem>> GetAllowedMenuAsync(int patientId, string tenantId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = @"
                SELECT m.* 
                FROM Patients p
                JOIN MenuItems m ON m.TenantId = p.TenantId
                WHERE p.Id = @Id 
                  AND p.TenantId = @TenantId
                  AND m.TenantId = @TenantId
                  AND (
                    p.DietaryRestrictionCode = 'NONE'
                    OR (p.DietaryRestrictionCode = 'GF' AND m.IsGlutenFree = 1)
                    OR (p.DietaryRestrictionCode = 'SF' AND m.IsSugarFree = 1)
                  )";

            return await connection.QueryAsync<MenuItem>(sql, new { Id = patientId, TenantId = tenantId });
        }
    }
}
