namespace BattleFieldGameLib.Common
{
    using BattleFieldGameLib.Interfaces;

    public class User
    {
        public User(string username) 
        {
            this.Username = username;
        }
        public int FieldSize { get; set; }

        public string Username { get; set; }

        public IPosition LastInput { get; set; }
    }
}
