using MageSurvivor.PlayerProfile;

namespace MageSurvivor
{
    public class GameScenario : IGameScenario
    {
        private IPlayer _player;
        private IProfile _profile;
        private PlayerCreator _playerCreator;

        public GameScenario(IProfile profile, PlayerCreator playerCreator)
        {
            _profile = profile;
            _playerCreator = playerCreator;
        }

        public void StartGame()
        {
            _player = _playerCreator.CreatePlayer();
            _player.Died += EndGame;
        }

        private void EndGame()
        {
            _player.Died -= EndGame;

            //TODO Show end game
        }
    }
}
