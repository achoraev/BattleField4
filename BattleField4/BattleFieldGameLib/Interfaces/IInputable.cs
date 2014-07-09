namespace BattleFieldGameLib
{
    public interface IInputable
    {
        int GetFieldSize();

        IPosition GetPositon();

        string GetUsername();
    }
}
