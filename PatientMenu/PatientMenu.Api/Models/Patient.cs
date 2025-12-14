namespace PatientMenu.Api.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string DietaryRestrictionCode { get; set; } // NONE, GF, SF
        public required string TenantId { get; set; }
    }
}
