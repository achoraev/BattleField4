namespace BattleFieldGameLib.Interfaces
{
    public interface IUser
    {
        int FieldSize { get; set; }

        string Username { get; set; }

        IPosition LastInput { get; set; }
    }
}
