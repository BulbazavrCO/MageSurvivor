using UnityEngine;

namespace MageSurvivor
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private Transform _self;

        private float _moveSpeed;         

        private void Awake()
        {
            var components = GetComponentInChildren<IComponents>();
            components.AddMover(this);            
        }       

        public void Move(Vector2 direction)
        {
            _self.Translate(direction * _moveSpeed * Time.deltaTime);
            _self.LookAt(_self.position + new Vector3(direction.x, direction.y, _self.position.z));
        }         

        public void SetMoveSpeed(float moveSpeed)
        {
            _moveSpeed = moveSpeed;
        }
    }
}
