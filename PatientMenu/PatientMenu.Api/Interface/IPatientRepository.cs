using PatientMenu.Api.Models;

namespace PatientMenu.Api.Interface
{
    public interface IPatientRepository
    {
        Task<IEnumerable<MenuItem>> GetAllowedMenuAsync(int patientId, string tenantId);
    }
}
