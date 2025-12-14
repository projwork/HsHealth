namespace PatientMenu.Api.Models.DTOs
{
    public class CreatePatientDto
    {
        public required string Name { get; set; }
        public required string DietaryRestrictionCode { get; set; } // NONE, GF, SF
        public required string TenantId { get; set; }
    }
}
