using UnityEngine;
using MageSurvivor.Utils;

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

        private void OnDestroy()
        {
            _composition.Dispose(); 
        }
    }
}
