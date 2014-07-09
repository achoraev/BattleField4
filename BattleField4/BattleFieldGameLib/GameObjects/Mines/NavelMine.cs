namespace BattleFieldGameLib
{

    using System;

    public class NavelMine : Mine
    {
       public NavelMine()
        {
            this.CreateMine();
            this.Power = MinePower.Three;
        }

        public override int[,] GetBlastArea()
        {
            return this.mineBody;
        }

        public override void CreateMine()
        {
            this.mineBody = new int[,] {{0,0,1,0,0},
										{0,1,1,1,0},
										{1,1,1,1,1},
										{0,1,1,1,0},
										{0,0,1,0,0}};
        }
    }
}
