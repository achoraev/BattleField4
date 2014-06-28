
namespace BattleFieldGameLib
{
    public abstract class UserInput
    {
        public int FieldSize { get; set; }
        public string Username { get; set; }

        public abstract int GetFieldSize();

        public abstract IPosition GetPositon();

        public abstract string GetUsername();
    }
}
