using MageSurvivor.PlayerProfile;

namespace MageSurvivor
{
    public class BalancePresenter
    {
        private IProfile _profile;
        private IBalanceView _balanceView;

        private ViewManager _viewManager;

        public BalancePresenter(IViewFactory viewFactory, ViewManager viewManager, IProfile profile)
        {
            _balanceView = viewFactory.CreateView<IBalanceView>(EViews.BalanceView);

            _profile = profile;
            _viewManager = viewManager;
        }

        public void Enable()
        {
            _balanceView.Enable();
            _viewManager.Register(_balanceView);

            UpdateView();

            _profile.BalanceChanged += UpdateView;
        }

        public void Disable()
        {
            _balanceView.Disable();
            _viewManager.UnRegister(_balanceView);

            _profile.BalanceChanged -= UpdateView;
        }

        private void UpdateView()
        {
            var balance = _profile.GetBalance();
            _balanceView.SetBalance(balance);
        }
    }
}
