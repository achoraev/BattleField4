using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class MineOne : Mine
    {
        public override void Explode()
        {
            throw new NotImplementedException();
        }

        public override Mine CreateMine()
        {
               return int[,] one = 
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 0, 1, 0},
                    {0,0,1,0,0},
                    {0,1,0,1,0},
                    {0,0,0,0,0}
                };
        }
    }
}
