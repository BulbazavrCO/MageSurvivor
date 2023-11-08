using MageSurvivor.Utils;

namespace MageSurvivor
{
    public class MobileViewFactory : IViewFactory
    {
        private UIRoot _uiRoot;
        private IResourceManager _resourceManager;

        public MobileViewFactory(UIRoot uIRoot, IResourceManager resourceManager)
        {
            _uiRoot = uIRoot;
            _resourceManager = resourceManager;
        }

        public TResult CreateView<TResult>(EViews type) where TResult : class
        {
            var mobileType = (EMobileViews)type;
            var resource = _resourceManager.GetFromPool<EMobileViews, TResult>(mobileType);
            var view = (IView)resource;
            view.SetParrent(_uiRoot.transform);

            return resource;
        }             
    }
}
