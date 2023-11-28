using UnityEngine;

namespace MageSurvivor
{
    public interface IInput
    {
        Vector2 ReadInput();

        void Enable();
        void Disable();
    }
}
