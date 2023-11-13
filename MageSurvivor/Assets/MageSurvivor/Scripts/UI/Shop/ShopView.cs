using System;
using System.Collections.Generic;
using UnityEngine;

namespace MageSurvivor
{
    public class ShopView : MonoBehaviour, IShopView
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private GameObject _content;

        public EViewLayer ViewLayer => EViewLayer.General;

        public event Action<int> CoinsBuyClicked = id => { };
        public event Action<int> CharacterBuyClicked = id => { };

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

        public void SetCharacterProducts(List<CharacterProductInfo> characterProducts)
        {
            
        }       
    }
}
