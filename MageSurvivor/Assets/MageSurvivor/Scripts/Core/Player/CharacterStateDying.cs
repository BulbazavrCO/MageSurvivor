using UnityEngine;

namespace MageSurvivor.CharacterBehaviorStates
{
    public class CharacterStateDying : ICharacterState
    {
        private CharacterBehavior _characterBehavior;

        private float _endAnimationTime;

        private const float DyingTime = 2.0f;

        public CharacterStateDying(CharacterBehavior characterBehavior)
        {
            _characterBehavior = characterBehavior;
        }

        public void Enter()
        {
            _characterBehavior.Character.Animator.Die();
            _characterBehavior.Character.BonusHolder.Disable();
            _endAnimationTime = Time.time + DyingTime;
        }

        public void Die()
        {
           
        }    

        public void StatsChanged()
        {
            
        }      

        public void Update()
        {
            if(Time.time > _endAnimationTime)
            {
                _characterBehavior.Character.Dispose();
            }
        }

        public void Reset()
        {
            _characterBehavior.SetState(_characterBehavior.StateIdle);            
        }       
    }
}
