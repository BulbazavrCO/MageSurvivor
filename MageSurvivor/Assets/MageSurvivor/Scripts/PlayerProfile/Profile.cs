using System;

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
    }
}
