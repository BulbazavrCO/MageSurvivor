namespace MageSurvivor.CharacterBehaviorStates
{
    public class CharacterStateIdle : ICharacterState
    {
        private IInput _input;
        private CharacterBehavior _characterBehavior;

        public CharacterStateIdle(CharacterBehavior characterBehavior, IInput input)
        {
            _input = input;
            _characterBehavior = characterBehavior;
        }

        public void Enter()
        {            
            _characterBehavior.Character.Animator.Idle();
            _characterBehavior.Character.BonusHolder.Activate();
        }       

        public void Update()
        {
            var inputDirection = _input.ReadInput();

            if(inputDirection.sqrMagnitude > 0)
            {
                _characterBehavior.SetState(_characterBehavior.StateMove);
            }
        }

        public void Die()
        {           
            _characterBehavior.SetState(_characterBehavior.StateDying);
        }

        public void StatsChanged()
        {
           
        }

        public void Reset()
        {
            
        }       
    }
}
