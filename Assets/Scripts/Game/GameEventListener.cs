namespace Game
{
    public interface IGameEventListener
    {
        /// <summary>
        /// Called when the player killed an enemy.
        /// </summary>
        void OnEnemyKilled();
    }
}