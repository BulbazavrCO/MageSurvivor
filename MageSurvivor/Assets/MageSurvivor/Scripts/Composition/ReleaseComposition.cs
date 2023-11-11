using MageSurvivor.PlayerProfile;
using MageSurvivor.Utils;

namespace MageSurvivor
{
    public class ReleaseComposition : IComposition
    {
        private IViewFactory _viewFactory;
        private IResourceManager _resourcesManager;
        private IGameConfiguration _gameConfiguration;

        // Long living objects
        private IProfile _profile;
        private IConfigReader _configReader;

        public void Dispose()
        {
            _viewFactory = null;
            _resourcesManager = null;
            _gameConfiguration = null;
        }

        public IProfile GetProfile()
        {
            if(_profile == null)
            {
                var gameConfiguration = GetGameConfiguration();
                _profile = new Profile(gameConfiguration);
            }

            return _profile;
        }

        public IViewFactory GetViewFactory()
        {
            if(_viewFactory == null)
            {
                var uiRoot = MonoExtention.MakeComponent<UIRoot>();
                var resourcesManager = GetResourceManager();

                _viewFactory = new MobileViewFactory(uiRoot, resourcesManager);
            }

            return _viewFactory;
        }

        public IResourceManager GetResourceManager()
        {
            if(_resourcesManager == null)
            {
                _resourcesManager = new ResourceManager();
            }

            return _resourcesManager;
        }

        public IConfigReader GetConfigReader()
        {
            if(_configReader == null)
            {
                _configReader = new ConfigReader();
            }

            return _configReader;
        }

        public IGameConfiguration GetGameConfiguration()
        {
            if(_gameConfiguration == null)
            {
                var configReader = GetConfigReader();
                _gameConfiguration = configReader.GetGameConfiguration();
            }

            return _gameConfiguration;
        }
    }
}
