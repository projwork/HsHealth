using PatientMenu.Api.Models.DTOs;

namespace PatientMenu.Api.Interface
{
    public interface IMenuService
    {
        Task<MenuItemDto> CreateMenuItemAsync(CreateMenuItemDto menuItem);
        Task<IEnumerable<MenuItemDto>> GetAllAsync(string tenantId);
    }
}
