namespace PatientMenu.Api.Models.DTOs
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Category { get; set; }
        public bool? IsGlutenFree { get; set; }
        public bool? IsSugarFree { get; set; }
        public bool? IsHeartHealthy { get; set; }
        public string TenantId { get; set; } = string.Empty;
    }
}
