namespace BattleFieldGameLib.Core
{
    using System;
    using System.Collections.Generic;
    using BattleFieldGameLib.Enums;
    using BattleFieldGameLib.GameObjects.Mines;
    using BattleFieldGameLib.Interfaces;

    /// <summary>
    /// Flyweight and Factory design patterns for the MineCreator. Inherits MineFactory.
    /// </summary>
    public class MineCreator : MineFactory
    {
        /// <summary>
        /// List of all currently created mines.
        /// </summary>
        private Dictionary<MinePower, IExplodable> createdMines;

        /// <summary>
        /// Initializes a new instance of the <see cref="MineCreator" /> class.
        /// </summary>
        public MineCreator()
        {
            this.createdMines = new Dictionary<MinePower, IExplodable>();
        }

        /// <summary>
        /// Creates a mine based on the given MinePower.
        /// </summary>
        /// <param name="power">Accepts MinePower enumeration.</param>
        /// <returns>Returns an instance of the IMine interface for the current mine power.</returns>
        public override IExplodable CreateMine(MinePower power)
        {
            IExplodable mineToReturn = null;

            if (this.createdMines.ContainsKey(power))
            {
                mineToReturn = this.createdMines[power];
            }
            else
            {
                switch (power)
                {
                    case MinePower.One:
                        mineToReturn = new LimpetMine(); 
                        break;
                    case MinePower.Two:
                        mineToReturn = new LandMine(); 
                        break;
                    case MinePower.Three:
                        mineToReturn = new NavelMine(); 
                        break;
                    case MinePower.Four:
                        mineToReturn = new NuclearMine(); 
                        break;
                    case MinePower.Five:
                        mineToReturn = new FatherBomb(); 
                        break;
                    default:
                        throw new ArgumentException(string.Format("Mine with power: {0}, does not exists YET!", power));
                }

                this.createdMines.Add(power, mineToReturn);
            }

            return mineToReturn;
        }
    }
}
