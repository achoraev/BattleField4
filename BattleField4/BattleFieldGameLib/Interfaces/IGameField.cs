namespace BattleFieldGameLib.Interfaces
{
    public interface IGameField : IDrawable
    {
        char[,] FieldBody { get; set; }

        char this[int row, int col]
        {
            get;
            set;
        }
    }
}
