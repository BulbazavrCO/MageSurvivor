using MageSurvivor.PlayerProfile;

namespace MageSurvivor
{
    public class ShopPresenter
    {
        private IProfile _profile;

        private ViewManager _viewManager;

        public ShopPresenter(IViewFactory viewFactory, ViewManager viewManager, IProfile profile)
        {
            _profile = profile;
            _viewManager = viewManager;
        }

        public void Enable()
        {
            UpdateView();
        }

        public void Disable()
        {

        }

        private void UpdateView()
        {
            var characters = _profile.GetCharacterProducts();
        }
    }
}
