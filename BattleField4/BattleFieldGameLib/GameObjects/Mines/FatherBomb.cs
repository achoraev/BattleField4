namespace BattleFieldGameLib.GameObjects.Mines
{
    using System;
    using BattleFieldGameLib.Enums;

    /// <summary>
    /// A mine class. Inherits base class Mine. Using factory pattern for creating the mines.
    /// </summary>
    public class FatherBomb : Mine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FatherBomb" /> class.
        /// </summary>
        public FatherBomb()
        {
            this.CreateMine();
            this.Power = MinePower.Five;
        }

        /// <summary>
        /// Sets the mine body.
        /// </summary>
        public override void CreateMine()
        {
            this.MineBody = new int[,]
            {
                { 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1 }
            };
        }
    }
}
