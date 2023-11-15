using UnityEngine;

namespace MageSurvivor
{
    public class GameCamera : MonoBehaviour
    {        
        [SerializeField] private Vector3 _offset;

        private Transform _target;        

        public void Setup(Transform target)
        {
            _target = target;
            LateUpdate();
        }

        private void LateUpdate()
        {
            if (_target == null)
                return;

            transform.position = _target.position + _offset;
        }
    }
}
