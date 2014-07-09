namespace BattleFieldGameLib
{

    using System;

    public class LimpetMine : Mine
    {
        public LimpetMine()
        {
            this.CreateMine();
            this.Power = MinePower.One;
        }

        public override int[,] GetBlastArea()
        {
            return this.mineBody;
        }

        public override void CreateMine()
        {
            this.mineBody = new int[,] {{0,0,0,0,0},
									    {0,1,0,1,0},
									    {0,0,1,0,0},
									    {0,1,0,1,0},
									    {0,0,0,0,0}};
        }
    }
}
