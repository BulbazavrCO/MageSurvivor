namespace MageSurvivor
{
    public class MenuPresenter
    {
        private IMenuView _menuView;
        private ViewManager _viewManager;
        private ShopPresenter _shopPresenter;
        private CharactersPresenter _charactersPresenter;

        public MenuPresenter(IViewFactory viewFactory, ViewManager viewManager, ShopPresenter shopPresenter, CharactersPresenter charactersPresenter)
        {
            _menuView = viewFactory.CreateView<IMenuView>(EViews.MenuView);

            _viewManager = viewManager;
            _shopPresenter = shopPresenter;
            _charactersPresenter = charactersPresenter;
        }

        public void Enable()
        {
            _menuView.Enable();
            _viewManager.Register(_menuView);

            _menuView.PlayButtonClicked += Play;
            _menuView.ShopButtonClicked += OpenShop;
            _menuView.CharactersButtonClicked += OpenCharacters;
        }

        public void Disable()
        {
            _menuView.Disable();
            _viewManager.UnRegister(_menuView);

            _menuView.PlayButtonClicked -= Play;
            _menuView.ShopButtonClicked -= OpenShop;
            _menuView.CharactersButtonClicked -= OpenCharacters;
        }

        private void Play()
        {

        }

        private void OpenShop()
        {
            _shopPresenter.Enable();
        }

        private void OpenCharacters()
        {
            _charactersPresenter.Enable();
        }       
    }
}
