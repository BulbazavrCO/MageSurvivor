using UnityEngine;

namespace MageSurvivor
{
    public class BonusHolder : MonoBehaviour
    {
        private bool _isInteractable;

        private void Awake()
        {
            var characterComponents = GetComponentInChildren<ICharacterComponents>();
            characterComponents.AddBonusHolder(this);
            _isInteractable = true;
        }

        public void Activate()
        {
            _isInteractable = true;
        }

        public void Disable()
        {
            _isInteractable = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isInteractable == false)
                return;

            if(other.TryGetComponent(out IBonus bonus))
            {
                bonus.Clollect();
            }
        }
    }
}
