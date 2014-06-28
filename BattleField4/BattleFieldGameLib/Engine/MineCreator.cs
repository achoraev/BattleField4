namespace BattleFieldGameLib
{
    using System;
    /// <summary>
    /// Factory Pattern - Concrete Mine Factory
    /// </summary>
    public class MineCreator : MineFactory
    {
        public override Mine CreateMine(MinePower power)
        {
            switch (power)
            {
                case MinePower.One:
                    return new LimpetMine();
                case MinePower.Two:
                    return new LandMine();
                case MinePower.Three:
                    return new NavelMine();
                case MinePower.Four:
                    return new NuclearMine();
                case MinePower.Five:
                    return new FatherBomb();
                default:
                    throw new ArgumentException(string.Format("Mine with power: {0}, does not exists YET!", power));
            }
        }
    }
}
