using PatientMenu.Api.Interface;
using PatientMenu.Api.Models.DTOs;
using PatientMenu.Api.Models;

namespace PatientMenu.Api.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<MenuItemDto> CreateMenuItemAsync(CreateMenuItemDto menuItem)
        {
            var newMenuItem = new MenuItem
            {
                Name = menuItem.Name,
                Category = menuItem.Category,
                IsGlutenFree = menuItem.IsGlutenFree,
                IsSugarFree = menuItem.IsSugarFree,
                IsHeartHealthy = menuItem.IsHeartHealthy,
                TenantId = menuItem.TenantId
            };
            var createdMenuItem = await _menuRepository.AddAsync(newMenuItem);
            return new MenuItemDto
            {
                Id = createdMenuItem.Id,
                Name = menuItem.Name,
                Category = menuItem.Category,
                IsGlutenFree = menuItem.IsGlutenFree,
                IsSugarFree = menuItem.IsSugarFree,
                IsHeartHealthy = menuItem.IsHeartHealthy,
                TenantId = menuItem.TenantId
            };
        }

        public async Task<IEnumerable<MenuItemDto>> GetAllAsync(string tenantId)
        {
            var menuItems = await _menuRepository.GetAllAsync(tenantId);
            return menuItems.Select(MapToDto);
        }

        private static MenuItemDto MapToDto(MenuItem item) => new()
        {
            Id = item.Id,
            Name = item.Name,
            Category = item.Category,
            IsGlutenFree = item.IsGlutenFree,
            IsSugarFree = item.IsSugarFree,
            IsHeartHealthy = item.IsHeartHealthy,
            TenantId = item.TenantId
        };
    }
}
