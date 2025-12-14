using PatientMenu.Api.Interface;
using PatientMenu.Api.Models.DTOs;

namespace PatientMenu.Api.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<MenuItemDto>> GetAllowedMenuAsync(int patientId, string tenantId)
        {
            var allowedMenu = await _patientRepository.GetAllowedMenuAsync(patientId, tenantId);

            return allowedMenu.Select(menuItem => new MenuItemDto
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Category = menuItem.Category,
                IsGlutenFree = menuItem.IsGlutenFree,
                IsSugarFree = menuItem.IsSugarFree,
                IsHeartHealthy = menuItem.IsHeartHealthy,
                TenantId = menuItem.TenantId
            });
        }
    }
}
