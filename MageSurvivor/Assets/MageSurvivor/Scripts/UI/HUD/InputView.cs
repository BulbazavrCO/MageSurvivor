using System;
using UnityEngine;

namespace MageSurvivor
{
    public class InputView : MonoBehaviour, IInputView
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private GameObject _content;        
        [SerializeField] private Joystick _joystick;

        public EViewLayer ViewLayer => EViewLayer.Input;

        public event Action DirectionClosed = () => { };
        public event Action<Vector2> DirectionChanged = direction => { };

        public void Enable()
        {
            _content.SetActive(true);
        }

        public void Disable()
        {
            _content.SetActive(false);
        }       

        public void SetCanvasOrder(int canvasOrder)
        {
            _canvas.sortingOrder = canvasOrder;
        }

        public void SetParrent(Transform parent)
        {
            transform.SetParent(parent, false);
        }

        private void HandleDirectionChanged(Vector2 direction)
        {
            DirectionChanged(direction);
        }

        private void HandleDirectionClosed()
        {
            DirectionClosed();
        }

        private void OnEnable()
        {
            _joystick.Closed += HandleDirectionClosed;
            _joystick.DirectionChanged += HandleDirectionChanged;          
        }

        private void OnDisable()
        {
            _joystick.Closed -= HandleDirectionClosed;
            _joystick.DirectionChanged -= HandleDirectionChanged;
        }
    }
}
