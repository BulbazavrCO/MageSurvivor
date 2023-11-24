namespace MageSurvivor.CharacterBehaviorStates
{
    public interface ICharacterBehavior
    {
        void Die();
        void Reset();

        void Update();

        void StatsChaged();
    }
}
