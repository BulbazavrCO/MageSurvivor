using MageSurvivor.Utils;

namespace MageSurvivor
{
    public class ReleaseComposition : IComposition
    {
        private IViewFactory _viewFactory;
        private IResourceManager _resourcesManager;

        public void Dispose()
        {
            _viewFactory = null;
            _resourcesManager = null;
        }

        public IViewFactory GetViewFactory()
        {
            if(_viewFactory == null)
            {
                var uiRoot = MonoExtention.MakeComponent<UIRoot>();
                var resourcesManager = GetResourceManager();

                _viewFactory = new MobileViewFactory(uiRoot, resourcesManager);
            }

            return _viewFactory;
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
