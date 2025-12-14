using Dapper;
using Microsoft.Data.Sqlite;

namespace PatientMenu.Api.Data
{
    public class DatabaseBootstrap
    {
        private readonly string _connectionString;

        public DatabaseBootstrap(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? "Data Source=Patient.db";
        }

        public void Setup()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            connection.Execute(@"
                CREATE TABLE IF NOT EXISTS Patients (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    DietaryRestrictionCode TEXT NOT NULL,
                    TenantId TEXT NOT NULL
                );
            ");
            
            var count = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Patients");
            if (count == 0)
            {
                connection.Execute("INSERT INTO Patients (Name, DietaryRestrictionCode, TenantId) VALUES (@Name, @DietaryRestrictionCode, @TenantId)", new[] {
                    new { Name = "John Doe", DietaryRestrictionCode = "GF", TenantId = "1" },
                    new { Name = "Jane Smith", DietaryRestrictionCode = "SF", TenantId = "1" },
                    new { Name = "Bob Jones", DietaryRestrictionCode = "NONE", TenantId = "1" }
                });
            }
        }
    }
}
