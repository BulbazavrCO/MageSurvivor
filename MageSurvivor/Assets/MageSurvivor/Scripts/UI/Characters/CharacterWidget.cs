using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MageSurvivor
{
    public class CharacterWidget : MonoBehaviour
    {
        public event Action<int> InfoButtonClicked = id => { };
        public event Action<int> SelectButtonClicked = id => { };

        [SerializeField] private Button _info;
        [SerializeField] private Button _select;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private GameObject _selected;

        private int _id;

        public void SetCharacter(CharacterInfo character)
        {
            _select.gameObject.SetActive(character.IsSelected == false);
            _selected.SetActive(character.IsSelected);
            _name.text = character.Name;
            _level.text = $"Level {character.Level}";
        }

        private void Select()
        {
            InfoButtonClicked(_id);
        }

        private void Info()
        {
            SelectButtonClicked(_id);
        }

        private void OnEnable()
        {
            _info.onClick.AddListener(Info);
            _select.onClick.AddListener(Select);            
        }

        private void OnDisable()
        {
            _info.onClick.RemoveListener(Info);
            _select.onClick.RemoveListener(Select);
        }
    }
}
