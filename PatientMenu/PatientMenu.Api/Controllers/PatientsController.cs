using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientMenu.Api.Interface;

namespace PatientMenu.Api.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientsController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet("{patientId}/allowed-menu")]
        public async Task<IActionResult> GetAllowedMenu(int patientId)
        {
            if (!Request.Headers.TryGetValue("TenantId", out var tenantIdVal))
            {
                return BadRequest("TenantId header is required");
            }
            string tenantId = tenantIdVal.ToString();

            var items = await _service.GetAllowedMenuAsync(patientId, tenantId);
            return Ok(items);
        }
    }
}
