using MageSurvivor.Utils;

namespace MageSurvivor
{
    public class ReleaseComposition : IComposition
    {
        private IResourceManager _resourcesManager;

        public void Dispose()
        {
            _resourcesManager = null;
        }

        public IResourceManager GetResourceManager()
        {
            if(_resourcesManager == null)
            {
                _resourcesManager = new ResourceManager();
            }

            return _resourcesManager;
        }
    }
}
