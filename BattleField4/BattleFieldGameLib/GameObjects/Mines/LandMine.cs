namespace BattleFieldGameLib
{

    using System;

    public class LandMine : Mine
    {
        public LandMine()
        {
            this.CreateMine();
            this.Power = MinePower.Two;
        }

        public override int[,] GetBlastArea()
        {
            return this.mineBody;
        }

        public override void CreateMine()
        {
            this.mineBody = new int[,] {{0,0,0,0,0},
										{0,1,1,1,0},
										{0,1,1,1,0},
										{0,1,1,1,0},
										{0,0,0,0,0}};
        }
    }
}
