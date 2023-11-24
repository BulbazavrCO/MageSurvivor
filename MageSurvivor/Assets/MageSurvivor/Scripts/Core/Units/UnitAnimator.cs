using UnityEngine;

namespace MageSurvivor
{
    public class UnitAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private const float DefaultAnimationSpeed = 1.0f;

        private void Awake()
        {
            var components = GetComponentInChildren<IComponents>();
            components.AddAnimator(this);
        }

        public void Attack()
        {
            ClearAnimatios();
            _animator.SetTrigger(EAnimationStates.Attack.ToString());
        }

        public void Idle()
        {
            ClearAnimatios();
            _animator.SetBool(EAnimationStates.Idle.ToString(), true);
        }

        public void Move()
        {
            ClearAnimatios();
            _animator.SetBool(EAnimationStates.Move.ToString(), true);            
        }

        public void Die()
        {
            ClearAnimatios();
            _animator.SetTrigger(EAnimationStates.Die.ToString());
        }

        public void SetAnimationSpeed(float speed)
        {
            _animator.speed = speed;
        }

        public void SetDefaultAnimationSpeed()
        {
            _animator.speed = DefaultAnimationSpeed;
        }

        private void ClearAnimatios()
        {
            _animator.SetBool(EAnimationStates.Move.ToString(), false);
            _animator.SetBool(EAnimationStates.Idle.ToString(), false);
        }
    }
}
