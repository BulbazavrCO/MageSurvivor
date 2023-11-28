using MageSurvivor.PlayerProfile;
using MageSurvivor.Utils;
using MageSurvivor.Configs;

namespace MageSurvivor
{
    public class ReleaseComposition : IComposition
    {
        private IInput _input;
        private IViewFactory _viewFactory;
        private IGameScenario _gameScenario;
        private IUnitRepository _unitRepository;        
        private IResourceManager _resourcesManager;        
        private IGameConfiguration _gameConfiguration;
      
        private ViewManager _viewManager;
        private PlayerCreator _playerCreator;
        private MenuPresenter _menuPresenter;
        private ShopPresenter _shopPresenter;
        private InputPresenter _inputPresenter;
        private BalancePresenter _balancePresenter;        
        private CharactersPresenter _charactersPresenter;

        // Long living objects
        private IProfile _profile;      
        private IConfigReader _configReader;
        private IProfileStorage _profileStorage;

        public void Dispose()
        {
            _input = null;           
            _viewFactory = null;
            _viewManager = null;
            _playerCreator = null;
            _menuPresenter = null;
            _shopPresenter = null;
            _inputPresenter = null;
            _balancePresenter = null;
            _resourcesManager = null;            
            _gameConfiguration = null;
            _charactersPresenter = null;
        }

        public IInput GetInput()
        {
            if(_input == null)
            {
                _input = new MobileInput(GetInputPresenter());
            }

            return _input;
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

        public IGameScenario GetGameScenario()
        {
            if(_gameScenario == null)
            {
                _gameScenario = new GameScenario(GetProfile(), GetPlayerCreator());
            }

            return _gameScenario;
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

        public IUnitRepository GetUnitRepository()
        {
            if(_unitRepository == null)
            {
                _unitRepository = new UnitRepository();
            }

            return _unitRepository;
        }

        public ViewManager GetViewManager()
        {
            if(_viewManager == null)
            {
                _viewManager = new ViewManager();
            }

            return _viewManager;
        }

        public BalancePresenter GetBalancePresenter()
        {
            if(_balancePresenter == null)
            {
                _balancePresenter = new BalancePresenter(GetViewFactory(), GetViewManager(), GetProfile());
            }

            return _balancePresenter;
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
                _shopPresenter = new ShopPresenter(GetViewFactory(), GetViewManager(), GetProfile());
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

        public PlayerCreator GetPlayerCreator()
        {
            if(_playerCreator == null)
            {
                _playerCreator = new PlayerCreator(GetProfile(), GetUnitRepository(), GetResourceManager());
            }

            return _playerCreator;
        }

        private InputPresenter GetInputPresenter()
        {
            if(_inputPresenter == null)
            {
                _inputPresenter = new InputPresenter(GetViewFactory(), GetViewManager());
            }

            return _inputPresenter;
        }
    }
}
