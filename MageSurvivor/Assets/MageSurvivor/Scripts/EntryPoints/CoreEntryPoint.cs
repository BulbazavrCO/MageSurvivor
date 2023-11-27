using UnityEngine;

namespace MageSurvivor
{
    public class CoreEntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            var gameScenario = CompositionRoot.GetGameScenario();
            gameScenario.StartGame();
            CreateMap();
        }

        private void CreateMap()
        {
            var resourceManager = CompositionRoot.GetResourceManager();
            resourceManager.CreatePrefabInstance(EGameComponents.GameArena);
        }
    }
}
