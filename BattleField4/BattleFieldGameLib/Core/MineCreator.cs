namespace BattleFieldGameLib.Core
{
    using System;
    using System.Collections.Generic;
    using BattleFieldGameLib.GameObjects.Mines;
    using BattleFieldGameLib.Enums;
    using BattleFieldGameLib.Interfaces;
    /// <summary>
    /// Flyweight design pattern
    /// </summary>
    public class MineCreator : MineFactory
    {
        private Dictionary<MinePower, Mine> createdMines;

        public MineCreator()
        {
            createdMines = new Dictionary<MinePower, Mine>();
        }

        public override IMine CreateMine(MinePower power)
        {
            Mine mineToReturn = null;

            if (this.createdMines.ContainsKey(power))
            {
                mineToReturn = this.createdMines[power];
            }
            else
            {
                switch (power)
                {
                    case MinePower.One:
                        mineToReturn = new LimpetMine(); break;
                    case MinePower.Two:
                        mineToReturn = new LandMine(); break;
                    case MinePower.Three:
                        mineToReturn = new NavelMine(); break;
                    case MinePower.Four:
                        mineToReturn = new NuclearMine(); break;
                    case MinePower.Five:
                        mineToReturn = new FatherBomb(); break;
                    default:
                        throw new ArgumentException(string.Format("Mine with power: {0}, does not exists YET!", power));
                }

                this.createdMines.Add(power, mineToReturn);
            }
            return mineToReturn;
        }
    }
}
