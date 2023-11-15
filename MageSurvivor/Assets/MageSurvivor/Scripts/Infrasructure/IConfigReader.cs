using MageSurvivor.PlayerProfile;

namespace MageSurvivor.Configs
{
    public interface IConfigReader
    {
        public ProfileState InitializeProfileState();
        public IGameConfiguration GetGameConfiguration();
    }
}
