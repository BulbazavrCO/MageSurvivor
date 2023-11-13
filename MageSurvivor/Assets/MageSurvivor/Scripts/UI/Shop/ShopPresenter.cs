using MageSurvivor.PlayerProfile;

namespace MageSurvivor
{
    public class ShopPresenter
    {
        private IProfile _profile;
        private IShopView _shopView;

        private ViewManager _viewManager;

        public ShopPresenter(IViewFactory viewFactory, ViewManager viewManager, IProfile profile)
        {
            _shopView = viewFactory.CreateView<IShopView>(EViews.ShopView);

            _profile = profile;
            _viewManager = viewManager;
        }

        public void Enable()
        {
            _shopView.Enable();
            _viewManager.Register(_shopView);
            UpdateView();
        }

        public void Disable()
        {
            _shopView.Disable();
            _viewManager.UnRegister(_shopView);
        }

        private void UpdateView()
        {
            var characters = _profile.GetCharacterProducts();

            _shopView.SetCharacterProducts(characters);
        }
    }
}
