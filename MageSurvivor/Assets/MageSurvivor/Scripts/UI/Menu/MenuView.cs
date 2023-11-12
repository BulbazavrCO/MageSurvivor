using System;
using UnityEngine;
using UnityEngine.UI;

namespace MageSurvivor
{
    public class MenuView : MonoBehaviour, IMenuView
    {
        [SerializeField] private Canvas _canvas;

        [SerializeField] private Button _play;
        [SerializeField] private Button _shop;
        [SerializeField] private Button _characters;

        public EViewLayer ViewLayer => EViewLayer.General;

        public event Action PlayButtonClicked = () => { };
        public event Action ShopButtonClicked = () => { };        
        public event Action CharactersButtonClicked = () => { };

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }        

        public void SetCanvasOrder(int canvasOrder)
        {
            _canvas.sortingOrder = canvasOrder;
        }

        public void SetParrent(Transform parent)
        {
            transform.SetParent(parent, false);
        }

        private void PlayClicked()
        {
            PlayButtonClicked();
        }

        private void ShopClicked()
        {
            ShopButtonClicked();
        }
        
        private void CharactersClicked()
        {
            CharactersButtonClicked();
        }

        private void OnEnable()
        {
            _play.onClick.AddListener(PlayClicked);
            _shop.onClick.AddListener(ShopClicked);
            _characters.onClick.AddListener(CharactersClicked);
        }

        private void OnDisable()
        {
            _play.onClick.RemoveListener(PlayClicked);
            _shop.onClick.RemoveListener(ShopClicked);
            _characters.onClick.RemoveListener(CharactersClicked);
        }
    }
}
