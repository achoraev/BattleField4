namespace BattleFieldGameLib
{
    public class User
    {
        public User(string username) 
        {
            this.Username = username;
        }
        public int FieldSize { get; set; }

        public string Username { get; set; }

        public int[,] LastInput { get; set; }
    }
}
