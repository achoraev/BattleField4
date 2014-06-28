namespace BattleFieldGameLib
{

    using System;

    public class NuclearMine : Mine
    {
        public NuclearMine()
        { 
            this.BlastArea = new int[,]{
                    {0,0,0,0,0},
                    {0,1,0,1,0},
                    {0,0,1,0,0},
                    {0,1,0,1,0},
                    {0,0,0,0,0}
                };

            this.Power = MinePower.Four;
        }

        public override void Explode()
        {
            throw new NotImplementedException();
        }
    }
}
