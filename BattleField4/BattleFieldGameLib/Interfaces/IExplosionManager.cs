using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleFieldGameLib.GameObjects.Fields;

namespace BattleFieldGameLib.Interfaces
{
    public interface IExplosionManager
    {
        void SetHitPosition(IPosition position);
        void SetMine(IExplodable mine);
        int HandleExplosion();
    }
}
