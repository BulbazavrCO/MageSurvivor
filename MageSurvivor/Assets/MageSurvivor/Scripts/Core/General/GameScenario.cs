using MageSurvivor.PlayerProfile;

namespace MageSurvivor
{
    public class GameScenario
    {
        private IProfile _profile;

        public GameScenario(IProfile profile)
        {
            _profile = profile;
        }
    }
}
