using MageSurvivor.Utils;
using MageSurvivor.PlayerProfile;

namespace MageSurvivor
{
    public class PlayerCreator
    {
        private IProfile _profile;
        private IUnitRepository _unitRepository;
        private IResourceManager _resourceManager;

        public PlayerCreator(IProfile profile, IUnitRepository unitRepository, IResourceManager resourceManager)
        {
            _profile = profile;
            _unitRepository = unitRepository;
            _resourceManager = resourceManager;
        }

        public IPlayer CreatePlayer()
        {
            var characterInfo = _profile.GetSelectedCharacter();
            var player = _resourceManager.GetFromPool<ECharacters, IPlayer>(ECharacters.FireMage);
            player.Setup(characterInfo);
            _unitRepository.AddPlayer(player);

            var gameCamera = _resourceManager.CreatePrefabInstance<EGameComponents, GameCamera>(EGameComponents.GameCamera);
            gameCamera.Setup(player.Pivot);

            return player;
        }
    }
}
