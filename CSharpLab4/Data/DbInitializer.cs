//using CSharpLab4.Models;

//namespace CSharpLab4.Data
//{
//    public static class DbInitializer
//    {
//        public static void Initialize(UserContext context)
//        {
//            if (context.Players.Any())
//                return;
//            var carlo = new Coach
//            {
//                FirstName = "Carlo",
//                LastName = "Ancelotti",
//                CoachID = 1
//            };
//            var xavier = new Coach
//            {
//                FirstName = "Xavier",
//                LastName = "Hernandez",
//                CoachID = 2
//            };
//            var coachs = new Coach[]
//            {
//                carlo,
//                xavier
//            };
//            var real_madrid = new Team
//            {
//                Name = "Real Madrid",
//                Coach = carlo,
//                TeamID = 1
//            };
//            var barcelona = new Team
//            {
//                Name = "Barcelona",
//                Coach = xavier,
//                TeamID = 2
//            };
//            var teams = new Team[]
//            {
//                real_madrid,
//                barcelona
//            };
//            var ronaldo = new Player
//            {
//                FirstName = "Ronaldo",
//                LastName = "Cristiano",
//                Age = 37,
//                Position = "Forward"
//            };
//            var messi = new Player
//            {
//                FirstName = "Lionel",
//                LastName = "Messi",
//                Age = 35,
//                Position = "Forward"
//            };
//            var xavi = new Player
//            {
//                FirstName = "Xavier",
//                LastName = "Hernandez",
//                Age = 42,
//                Position = "Half defender"
//            };
//            var enrollments = new Enrollment[]
//            {
//                new Enrollment
//                {
//                    Player = ronaldo,
//                    Team = real_madrid
//                },
//                new Enrollment
//                {
//                    Player = messi,
//                    Team = barcelona
//                },
//                new Enrollment
//                {
//                    Player = xavi,
//                    Team = barcelona
//                }
//            };
//            context.AddRange(enrollments);
//            context.SaveChanges();
//        }
//    }
//}
