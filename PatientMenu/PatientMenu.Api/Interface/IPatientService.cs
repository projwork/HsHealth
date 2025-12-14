using PatientMenu.Api.Models.DTOs;

namespace PatientMenu.Api.Interface
{
    public interface IPatientService
    {
        Task<IEnumerable<MenuItemDto>> GetAllowedMenuAsync(int patientId, string tenantId);
    }
}
