namespace Cosmedest.Application.DTOs
{
    public class UpdateProfileDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
