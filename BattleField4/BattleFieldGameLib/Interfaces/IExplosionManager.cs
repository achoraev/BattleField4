namespace BattleFieldGameLib.Interfaces
{
    /// <summary>
    /// Explosion handler interface.
    /// </summary>
    public interface IExplosionHandler
    {
        /// <summary>
        /// Gets or sets the field blast representation.
        /// </summary>
        /// <value>A character.</value>
        char FieldBlastRepresentation { get; set; }

        /// <summary>
        /// Set the position for the next hit.
        /// </summary>
        /// <param name="position">IPosition instance for the next hit coordinates.</param>
        void SetHitPosition(IPosition position);

        /// <summary>
        /// Sets a mine to the field.
        /// </summary>
        /// <param name="mine">An instance of IExplodable mine.</param>
        void SetMine(IExplodable mine);

        /// <summary>
        /// Handles the explosion to the given position.
        /// </summary>
        /// <returns>Integer as score.</returns>
        int HandleExplosion();
    }
}
