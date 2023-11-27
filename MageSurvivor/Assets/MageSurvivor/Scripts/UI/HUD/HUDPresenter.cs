using UnityEngine;

namespace MageSurvivor
{
    public class HUDPresenter : MonoBehaviour
    {
        private IPlayer _player;
        private IHUDVIew _hudView;
        private IUnitRepository _unitRepository;

        private ViewManager _viewManager;

        public HUDPresenter(IViewFactory viewFactory, ViewManager viewManager, IUnitRepository unitRepository)
        {
            _hudView = viewFactory.CreateView<IHUDVIew>(EViews.HUDView);
            _viewManager = viewManager;
            _unitRepository = unitRepository;
            _player = _unitRepository.GetPlayer();
        }

        public void Enable()
        {
            _player.HealthChanged += UpdatePlayerHealth;

            _viewManager.Register(_hudView);
            _hudView.Enable();

            UpdateView();
        }

        public void Disable()
        {
            _player.HealthChanged -= UpdatePlayerHealth;

            _viewManager.UnRegister(_hudView);
            _hudView.Disable();
        }        

        private void UpdateView()
        {
            UpdatePlayerHealth();
        }

        private void UpdatePlayerHealth()
        {
            var healthValue = _player.GetHealthPercent();
            _hudView.SetPlayerHealth(healthValue);
        }
    }
}
