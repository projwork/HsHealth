using PatientMenu.Api.Models;

namespace PatientMenu.Api.Interface
{
    public interface IMenuRepository
    {
        Task<MenuItem> AddAsync(MenuItem menuItem);
        Task<IEnumerable<MenuItem>> GetAllAsync(string tenantId);        
    }
}
