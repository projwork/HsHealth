using Microsoft.EntityFrameworkCore;
using PatientMenu.Api.Data;
using PatientMenu.Api.Interface;
using PatientMenu.Api.Models;

namespace PatientMenu.Api.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly MenuDbContext _context;

        public MenuRepository(MenuDbContext context)
        {
            _context = context;
        }

        public async Task<MenuItem> AddAsync(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();
            return menuItem;
        }

        public async Task<IEnumerable<MenuItem>> GetAllAsync(string tenantId)
        {
            return await _context.MenuItems
                .Where(m => m.TenantId == tenantId)
                .ToListAsync();
        }
    }
}
