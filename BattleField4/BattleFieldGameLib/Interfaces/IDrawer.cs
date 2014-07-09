namespace BattleFieldGameLib
{
    public interface IDrawer
    {
        void DrawObject(IDrawable drawableObject);
        void DrawText(string text);
    }
}
