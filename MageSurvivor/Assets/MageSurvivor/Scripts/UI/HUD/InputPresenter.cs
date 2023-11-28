using System;
using UnityEngine;

namespace MageSurvivor
{
    public class InputPresenter
    {
        private IInputView _inputView;

        private ViewManager _viewManager;

        public event Action DirectionClosed = () => { };
        public event Action<Vector2> DirectionChanged = direction => { };

        public InputPresenter(IViewFactory viewFactory, ViewManager viewManager)
        {
            _inputView = viewFactory.CreateView<IInputView>(EViews.InputView);
            _viewManager = viewManager;
        }

        public void Enable()
        {
            _inputView.DirectionClosed += HandleDirectionClosed;
            _inputView.DirectionChanged += HandleDirectionChanged;

            _viewManager.Register(_inputView);
            _inputView.Enable();
        }

        public void Disable()
        {
            _inputView.DirectionClosed += HandleDirectionClosed;
            _inputView.DirectionChanged += HandleDirectionChanged;

            _viewManager.UnRegister(_inputView);
            _inputView.Disable();
        }

        private void HandleDirectionClosed()
        {
            DirectionClosed();
        }

        private void HandleDirectionChanged(Vector2 direction)
        {
            DirectionChanged(direction);
        }       
    }
}
