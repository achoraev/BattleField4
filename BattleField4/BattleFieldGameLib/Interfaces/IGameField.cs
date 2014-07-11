using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFieldGameLib.Interfaces
{
    public interface IGameField : IDrawable
    {
        char this[int row, int col]
        {
            get;
            set;
        }

        char[,] FieldBody { get; set; }
    }
}
