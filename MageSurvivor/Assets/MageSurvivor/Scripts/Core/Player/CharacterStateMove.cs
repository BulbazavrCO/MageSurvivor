namespace MageSurvivor.CharacterBehaviorStates
{
    public class CharacterStateMove : ICharacterState
    {
        private IInput _input;
        private CharacterBehavior _characterBehavior;

        public CharacterStateMove(CharacterBehavior characterBehavior, IInput input)
        {
            _input = input;
            _characterBehavior = characterBehavior;
        }      

        public void Update()
        {
            var inputDirection = _input.ReadInput();
            if(inputDirection.sqrMagnitude == 0)
            {
                _characterBehavior.SetState(_characterBehavior.StateIdle);
            }

            _characterBehavior.Character.Mover.Move(inputDirection);
        }

        public void Enter()
        {
            _characterBehavior.Character.Animator.Move();
            UpdateMoveSpeed();           
        }

        public void Die()
        {           
            _characterBehavior.SetState(_characterBehavior.StateDying);
        }

        public void StatsChanged()
        {
            UpdateMoveSpeed();   
        }

        public void Reset()
        {
            _characterBehavior.SetState(_characterBehavior.StateIdle);
            _characterBehavior.Character.BonusHolder.Activate();
        }

        private void UpdateMoveSpeed()
        {
            var moveSpeed = _characterBehavior.Character.GetStatValue(EStats.MoveSpeed);
            _characterBehavior.Character.Mover.SetMoveSpeed(moveSpeed);
            _characterBehavior.Character.Animator.SetAnimationSpeed(moveSpeed);
        }
    }
}
