namespace CSharpLab4.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int PlayerID { get; set; }
        public int TeamID { get; set; }
        public Player Player { get; set; }
        public Team Team { get; set; }
    }
}
