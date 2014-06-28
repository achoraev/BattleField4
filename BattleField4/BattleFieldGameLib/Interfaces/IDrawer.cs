using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFieldGameLib
{
    public interface IDrawer
    {
        void DrawObject(IDrawable drawableObject);
    }
}
