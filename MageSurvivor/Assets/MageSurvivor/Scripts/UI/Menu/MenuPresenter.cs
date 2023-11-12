namespace MageSurvivor
{
    public class MenuPresenter
    {
        private IMenuView _menuView;
        private ViewManager _viewManager;

        public MenuPresenter(IViewFactory viewFactory, ViewManager viewManager)
        {
            _menuView = viewFactory.CreateView<IMenuView>(EViews.MenuView);

            _viewManager = viewManager;
        }

        public void Enable()
        {
            _menuView.Enable();
            _viewManager.Register(_menuView);
        }

        public void Disable()
        {
            _menuView.Disable();
            _viewManager.UnRegister(_menuView);
        }

        private void Play()
        {

        }

        private void OpenShop()
        {

        }

        private void OpenCharacters()
        {

        }
    }
}
