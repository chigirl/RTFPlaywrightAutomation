namespace RethinkFirst.Models
{
    public class Student
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string StudentId { get; set; }
        public required string AssignBuilding { get; set; }
        public required string Grade { get; set; }
        public required string Education { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }

        public string PhotoPath { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Ethnicity { get; set; } = string.Empty;
        public string Birthday { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string OtherDetails { get; set; } = string.Empty;
    }
}
