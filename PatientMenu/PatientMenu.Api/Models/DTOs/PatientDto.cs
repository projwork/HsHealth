namespace PatientMenu.Api.Models.DTOs
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DietaryRestrictionCode { get; set; } = string.Empty;
        public string TenantId { get; set; } = string.Empty;
    }
}
