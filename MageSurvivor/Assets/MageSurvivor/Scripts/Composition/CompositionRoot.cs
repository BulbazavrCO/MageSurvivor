using UnityEngine;
using MageSurvivor.Utils;

namespace MageSurvivor
{
    public class CompositionRoot : MonoBehaviour
    {
        public static IComposition Composition;

        public static IResourceManager GetResourceManager()
        {
            return Composition.GetResourceManager();
        }

        private void OnDestroy()
        {
            Composition.Dispose(); 
        }
    }
}
