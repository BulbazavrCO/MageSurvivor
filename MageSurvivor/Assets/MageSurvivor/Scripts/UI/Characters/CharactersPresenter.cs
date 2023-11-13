using MageSurvivor.PlayerProfile;

namespace MageSurvivor
{
    public class CharactersPresenter
    {
        private IProfile _profile;
        private ICharactersView _charactersView;

        private ViewManager _viewManager;

        public CharactersPresenter(IViewFactory viewFactory, ViewManager viewManager, IProfile profile)
        {
            _charactersView = viewFactory.CreateView<ICharactersView>(EViews.CharactersView);
            _viewManager = viewManager;
            _profile = profile;
        }

        public void Enable()
        {
            _charactersView.Enable();
            _viewManager.Register(_charactersView);
            UpdateView();

            _profile.CharactersChanged += UpdateView;
            _charactersView.BackButtonClicked += Disable;
            _charactersView.SelectCharaterClicked += SelectCharacter;
            _charactersView.InfoCharacterClicked += OpenCharacterInfo;            
        }

        public void Disable()
        {
            _charactersView.Disable();
            _viewManager.UnRegister(_charactersView);

            _profile.CharactersChanged -= UpdateView;
            _charactersView.BackButtonClicked -= Disable;
            _charactersView.SelectCharaterClicked -= SelectCharacter;
            _charactersView.InfoCharacterClicked -= OpenCharacterInfo;
        }

        private void UpdateView()
        {
            var characters = _profile.GetCharacters();

            _charactersView.SetCharacters(characters);
        }

        private void SelectCharacter(int id)
        {
            _profile.SelectCharacter(id);
        }

        private void OpenCharacterInfo(int id)
        {

        }
    }
}
