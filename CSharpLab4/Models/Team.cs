namespace CSharpLab4.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string Name { get; set; }
        public ICollection<Player> Players { get; set; }
        
        public ICollection<Enrollment> Enrollments { get; set; }
        public int CoachID { get; set; }
        public Coach Coach { get; set; }
    }
}
