namespace BattleFieldGameLib
{
    public interface IInputable
    {
        int GetFieldSize(IDrawer drawer);

        IPosition GetPositon(IDrawer drawer);

        string GetUsername();
    }
}
