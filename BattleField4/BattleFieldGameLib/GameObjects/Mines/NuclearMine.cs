namespace BattleFieldGameLib
{

    using System;

    public class NuclearMine : Mine
    {
        public NuclearMine()
        {
            this.CreateMine();
            this.Power = MinePower.Four;
        }

        public override int[,] GetBlastArea()
        {
            return this.mineBody;
        }

        public override void CreateMine()
        {
            this.mineBody = new int[,] {{0,1,1,1,0},
										{1,1,1,1,1},
										{1,1,1,1,1},
										{1,1,1,1,1},
										{0,1,1,1,0}};
        }
    }
}
