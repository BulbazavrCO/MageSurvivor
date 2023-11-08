using UnityEngine;

namespace MageSurvivor
{
    public interface IView
    {
        EViewLayer ViewLayer { get; }

        void Enable();
        void Disable();
        void SetParrent(Transform parent);
        void SetCanvasOrder(int canvasOrder);
    }
}
