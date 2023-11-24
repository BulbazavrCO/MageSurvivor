using UnityEngine;

namespace MageSurvivor
{
    public class MobileInput : IInput
    {
        private Vector2 _inputDirection = Vector2.zero;

        public Vector2 ReadInput()
        {
            return _inputDirection;
        }
    }
}
