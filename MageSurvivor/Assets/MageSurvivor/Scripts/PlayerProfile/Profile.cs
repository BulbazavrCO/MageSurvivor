using System;
using System.Collections.Generic;

namespace MageSurvivor.PlayerProfile
{
    public class Profile : IProfile
    {
        private ProfileState _profileState;
        private IGameConfiguration _gameConfiguration;

        public event Action BalanceChanged = () => { };
        public event Action CharactersChanged = () => { };

        public Profile(IGameConfiguration gameConfiguration)
        {
            _gameConfiguration = gameConfiguration;
        }

        public void SetState(ProfileState profileState)
        {
            _profileState = profileState;
        }

        public void BuyCharacter(int id)
        {
            var characterState = _profileState.Characters[id];
            var characterConfig = _gameConfiguration.GetCharacter(id);

            characterState.Level = 1;

            var cost = characterConfig.LevelsCost[0];
            _profileState.PlayerState.Coins -= cost;

            _profileState.PlayerState.Characters.Add(id);

            BalanceChanged();
            CharactersChanged();
        }

        public void LevelUpCharacter(int id)
        {
            var characterState = _profileState.Characters[id];
            var characterConfig = _gameConfiguration.GetCharacter(id);

            var cost = characterConfig.LevelsCost[characterState.Level];
            _profileState.PlayerState.Coins -= cost;

            characterState.Level++;

            BalanceChanged();
            CharactersChanged();
        }

        public void SelectCharacter(int id)
        {
            _profileState.PlayerState.SelectedCharacter = id;

            CharactersChanged();
        }

        public CharacterInfo GetCharacter(int id)
        {
            var characterState = _profileState.Characters[id];
            var characterConfig = _gameConfiguration.GetCharacter(id);

            var level = characterState.Level;
            var name = characterConfig.Name;
            var description = characterConfig.Description;
            var isMaxLevel = characterConfig.MaxLevel == level;
            var isSelected = _profileState.PlayerState.SelectedCharacter == id;
            var coinsToLevelUp = isMaxLevel ? 0 : characterConfig.LevelsCost[level];

            var characterInfo = new CharacterInfo(id, level, name, description, isMaxLevel, isSelected, coinsToLevelUp);

            return characterInfo;
        }

        public List<CharacterInfo> GetCharacters()
        {
            List<CharacterInfo> characters = new List<CharacterInfo>();

            foreach(var characterId in _profileState.PlayerState.Characters)
            {
                var charatcer = GetCharacter(characterId);
                characters.Add(charatcer);
            }

            return characters;
        }
    }
}
