namespace MageSurvivor.CharacterBehaviorStates
{
    public interface ICharacterState 
    {
        void Enter();

        void Die();
        void Reset();       

        void Update();
        void StatsChanged();
    }
}
