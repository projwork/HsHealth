namespace PatientMenu.Api.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Category { get; set; }
        public bool? IsGlutenFree { get; set; }
        public bool? IsSugarFree { get; set; }
        public bool? IsHeartHealthy { get; set; }
        public required string TenantId { get; set; }
    }
}
