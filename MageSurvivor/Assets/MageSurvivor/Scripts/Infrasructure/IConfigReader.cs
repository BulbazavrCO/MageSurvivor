using MageSurvivor.PlayerProfile;

namespace MageSurvivor
{
    public interface IConfigReader
    {
        public ProfileState InitializeProfileState();
        public IGameConfiguration GetGameConfiguration();
    }
}
