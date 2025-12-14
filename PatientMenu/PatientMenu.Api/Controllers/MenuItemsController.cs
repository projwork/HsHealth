using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientMenu.Api.Interface;
using PatientMenu.Api.Models.DTOs;

namespace PatientMenu.Api.Controllers
{
    [Route("api/menu-items")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuService _service;

        public MenuItemsController(IMenuService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuItem([FromBody] CreateMenuItemDto menuItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Get TenantId from header
            if (!Request.Headers.TryGetValue("TenantId", out var tenantIdVal))
            {
                return BadRequest("TenantId header is required");
            }

            menuItem.TenantId = tenantIdVal.ToString();

            var created = await _service.CreateMenuItemAsync(menuItem);
            return CreatedAtAction(nameof(CreateMenuItem), new { id = created.Id }, created);
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuItems()
        {
            if (!Request.Headers.TryGetValue("TenantId", out var tenantIdVal))
            {
                return BadRequest("TenantId header is required");
            }
            string tenantId = tenantIdVal.ToString();

            var items = await _service.GetAllAsync(tenantId);
            return Ok(items);
        }
    }
}
