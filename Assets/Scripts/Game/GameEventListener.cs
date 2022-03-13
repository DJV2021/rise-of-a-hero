namespace Game
{
    public interface IGameEventListener
    {
        /// <summary>
        /// Called when the player kill an enemy.
        /// </summary>
        void OnEnemyKilled();
    }
}