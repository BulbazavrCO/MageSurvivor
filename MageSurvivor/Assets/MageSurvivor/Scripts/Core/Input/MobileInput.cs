using UnityEngine;

namespace MageSurvivor
{
    public class MobileInput : IInput
    {
        private Vector2 _inputDirection = Vector2.zero;
        private InputPresenter _inputPresenter;

        public MobileInput(InputPresenter inputPresenter)
        {
            _inputPresenter = inputPresenter;

            Enable();
        }

        public void Enable()
        {
            _inputPresenter.Enable();

            _inputPresenter.DirectionChanged += HandleDirectionChanged;
            _inputPresenter.DirectionClosed += HandleDirectionClosed;
        }

        public void Disable()
        {
            _inputPresenter.Disable();

            _inputPresenter.DirectionChanged -= HandleDirectionChanged;
            _inputPresenter.DirectionClosed -= HandleDirectionClosed;
        }      

        public Vector2 ReadInput()
        {
            return _inputDirection;
        }

        private void HandleDirectionChanged(Vector2 direction)
        {
            _inputDirection = direction;
        }

        private void HandleDirectionClosed()
        {
            _inputDirection = Vector2.zero;
        }
    }
}
