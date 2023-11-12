using UnityEngine;

namespace MageSurvivor
{
    public class MetaEntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            var menuPresenter = CompositionRoot.GetMenuPresenter();
            menuPresenter.Enable();
        }
    }
}
