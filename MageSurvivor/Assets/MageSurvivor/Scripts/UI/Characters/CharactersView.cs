using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MageSurvivor.Utils;

namespace MageSurvivor
{
    public class CharactersView : MonoBehaviour, ICharactersView
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private GameObject _content;
        [SerializeField] private Transform _widgetsParent;

        [SerializeField] private Button _back;

        private IResourceManager _resourceManager;
        private List<CharacterWidget> _characterWidgets;

        public EViewLayer ViewLayer => EViewLayer.General;

        public event Action BackButtonClicked = () => { };
        public event Action<int> InfoCharacterClicked = id => { };
        public event Action<int> SelectCharaterClicked = id => { };        

        private void Awake()
        {
            _resourceManager = CompositionRoot.GetResourceManager();
            _characterWidgets = new List<CharacterWidget>();
        }

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

        public void SetCharacters(List<CharacterInfo> characters)
        {
            ClearWidgets();

            foreach(var character in characters)
            {
                var characterWidget = _resourceManager.GetFromPool<EWidgets, CharacterWidget>(EWidgets.CharacterWidget);
                characterWidget.transform.SetParent(_widgetsParent, false);
                characterWidget.SetCharacter(character);
                characterWidget.InfoButtonClicked += InfoClicked;
                characterWidget.SelectButtonClicked += SelectClicked;

                _characterWidgets.Add(characterWidget);
            }
        }

        private void BackClicked()
        {
            BackButtonClicked();
        }

        private void InfoClicked(int id)
        {
            InfoCharacterClicked(id);
        }

        private void SelectClicked(int id)
        {
            SelectCharaterClicked(id);
        }

        private void ClearWidgets()
        {
            foreach(var widget in _characterWidgets)
            {
                widget.InfoButtonClicked -= InfoClicked;
                widget.SelectButtonClicked -= SelectClicked;
                widget.gameObject.SetActive(false);
            }

            _characterWidgets.Clear();
        }

        private void OnEnable()
        {
            _back.onClick.AddListener(BackClicked);
        }

        private void OnDisable()
        {
            _back.onClick.RemoveListener(BackClicked);
            ClearWidgets();
        }       
    }
}
