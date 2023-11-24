namespace MageSurvivor.CharacterBehaviorStates
{
    public class CharacterBehavior : ICharacterBehavior
    {
        public BaseCharacter Character { get; }

        public ICharacterState StateIdle { get; }
        public ICharacterState StateMove { get; }
        public ICharacterState StateDying { get; }       

        private ICharacterState _currentState;

        public CharacterBehavior(BaseCharacter character, IInput input)
        {
            Character = character;

            StateIdle = new CharacterStateIdle(this, input);
            StateMove = new CharacterStateMove(this, input);
            StateDying = new CharacterStateDying(this);

            _currentState = StateIdle;
        }

        public void SetState(ICharacterState characterState)
        {
            _currentState = characterState;
            _currentState.Enter();
        }       

        public void Update()
        {
            _currentState.Update();
        }

        public void Die()
        {
            _currentState.Die();
        }

        public void StatsChaged()
        {
            _currentState.StatsChanged();
        }

        public void Reset()
        {
            _currentState.Reset();
        }
    }
}
