using UnityEngine;
using MageSurvivor.Utils;
using MageSurvivor.Configs;

namespace MageSurvivor
{
    public class CompositionRoot : MonoBehaviour
    {
        private static IComposition _composition = new ReleaseComposition();

        public static IViewFactory GetViewFactory()
        {
            return _composition.GetViewFactory();
        }

        public static IResourceManager GetResourceManager()
        {
            return _composition.GetResourceManager();
        }

        public static IProfileStorage GetProfileStorage()
        {
            return _composition.GetProfileStorage();
        }

        public static IGameScenario GetGameScenario()
        {
            return _composition.GetGameScenario();
        }

        public static IGameConfiguration GetGameConfiguration()
        {
            return _composition.GetGameConfiguration();
        }

        public static IInput GetInput()
        {
            return _composition.GetInput();
        }

        public static IUnitRepository GetUnitRepository()
        {
            return _composition.GetUnitRepository();
        }

        public static BalancePresenter GetBalancePresenter()
        {
            return _composition.GetBalancePresenter();
        }

        public static MenuPresenter GetMenuPresenter()
        {
            return _composition.GetMenuPresenter();
        }

        public static PlayerCreator GetPlayerCreator()
        {
            return _composition.GetPlayerCreator();
        }

        private void OnDestroy()
        {
            _composition.Dispose(); 
        }
    }
}
