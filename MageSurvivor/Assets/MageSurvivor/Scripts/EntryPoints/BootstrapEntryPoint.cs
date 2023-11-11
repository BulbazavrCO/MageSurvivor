using UnityEngine;
using UnityEngine.SceneManagement;

namespace MageSurvivor
{
    public class BootstrapEntryPoint : MonoBehaviour
    {
        private IProfileStorage _profileStorage;

        private void Awake()
        {
            _profileStorage = CompositionRoot.GetProfileStorage();

            _profileStorage.Load();
            LoadMeta();
        }

        private void LoadMeta()
        {
            SceneManager.LoadScene(EScenes.Meta.ToString());
        }
    }
}
