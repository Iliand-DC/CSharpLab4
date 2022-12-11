namespace CSharpLab4.Models
{
    public class Team
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Player> Players { get; set; }
        public int CoachID { get; set; }
        public Coach Coach { get; set; }
        public Team()
        {
            Players = new List<Player>();
        }
    }
}
