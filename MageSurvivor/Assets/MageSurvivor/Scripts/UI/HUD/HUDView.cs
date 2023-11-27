using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MageSurvivor
{
    public class HUDView : MonoBehaviour, IHUDVIew
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private GameObject _content;

        [SerializeField] private Slider _health;
        [SerializeField] private TextMeshProUGUI _healthPoints;

        public EViewLayer ViewLayer => EViewLayer.General;

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

        public void SetPlayerHealth(float value)
        {
            _health.value = value;
            _healthPoints.text = ((int)(value * 100)).ToString();
        }
    }
}
