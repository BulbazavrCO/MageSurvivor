using MageSurvivor.PlayerProfile;
using MageSurvivor.Utils;

namespace MageSurvivor
{
    public class ReleaseComposition : IComposition
    {
        private IViewFactory _viewFactory;
        private IResourceManager _resourcesManager;
        private IGameConfiguration _gameConfiguration;

        private ViewManager _viewManager;
        private MenuPresenter _menuPresenter;

        // Long living objects
        private IProfile _profile;      
        private IConfigReader _configReader;
        private IProfileStorage _profileStorage;

        public void Dispose()
        {
            _viewFactory = null;
            _viewManager = null;
            _menuPresenter = null;
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

        public IProfileStorage GetProfileStorage()
        {
            if(_profileStorage == null)
            {
                var profile = GetProfile();
                var configReader = GetConfigReader();

                _profileStorage = new ProfileStorage(profile, configReader);
            }

            return _profileStorage;
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

        public ViewManager GetViewManager()
        {
            if(_viewManager == null)
            {
                _viewManager = new ViewManager();
            }

            return _viewManager;
        }

        public MenuPresenter GetMenuPresenter()
        {
            if(_menuPresenter == null)
            {
                var viewFactory = GetViewFactory();
                var viewManager = GetViewManager();
                _menuPresenter = new MenuPresenter(viewFactory, viewManager);
            }

            return _menuPresenter;
        }
    }
}
