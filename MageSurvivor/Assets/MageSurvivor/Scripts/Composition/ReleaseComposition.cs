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
        private ShopPresenter _shopPresenter;
        private CharactersPresenter _charactersPresenter;

        // Long living objects
        private IProfile _profile;      
        private IConfigReader _configReader;
        private IProfileStorage _profileStorage;

        public void Dispose()
        {
            _viewFactory = null;
            _viewManager = null;
            _menuPresenter = null;
            _shopPresenter = null;
            _resourcesManager = null;            
            _gameConfiguration = null;
            _charactersPresenter = null;
        }

        public IProfile GetProfile()
        {
            if(_profile == null)
            {               
                _profile = new Profile(GetGameConfiguration());
            }

            return _profile;
        }

        public IViewFactory GetViewFactory()
        {
            if(_viewFactory == null)
            {
                var uiRoot = MonoExtention.MakeComponent<UIRoot>();        

                _viewFactory = new MobileViewFactory(uiRoot, GetResourceManager());
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
                _profileStorage = new ProfileStorage(GetProfile(), GetConfigReader());
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
                _menuPresenter = new MenuPresenter(GetViewFactory(), GetViewManager(), GetShopPresenter(), GetCharactersPresenter());
            }

            return _menuPresenter;
        }

        public ShopPresenter GetShopPresenter()
        {
            if(_shopPresenter == null)
            {               

                _shopPresenter = new ShopPresenter(GetViewFactory(), GetViewManager());
            }

            return _shopPresenter;
        }

        public CharactersPresenter GetCharactersPresenter()
        {
            if(_charactersPresenter == null)
            {
                _charactersPresenter = new CharactersPresenter(GetViewFactory(), GetViewManager(), GetProfile());
            }

            return _charactersPresenter;
        }
    }
}
