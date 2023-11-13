using UnityEngine;
using TMPro;

namespace MageSurvivor
{
    public class BalanceView : MonoBehaviour, IBalanceView
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private GameObject _content;

        [SerializeField] private TextMeshProUGUI _gems;
        [SerializeField] private TextMeshProUGUI _coins;

        public EViewLayer ViewLayer => EViewLayer.Balance;

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

        public void SetBalance(BalanceInfo balance)
        {
            _gems.text = $"Gems: {balance.Gems}";
            _coins.text = $"Coins: {balance.Coins}";
        }       
    }
}
