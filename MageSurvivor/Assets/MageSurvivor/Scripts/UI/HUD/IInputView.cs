using System;
using UnityEngine;

namespace MageSurvivor
{
    public interface IInputView : IView
    {
        event Action DirectionClosed;
        event Action<Vector2> DirectionChanged;
    }
}
