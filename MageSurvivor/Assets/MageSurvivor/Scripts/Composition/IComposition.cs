using System;
using MageSurvivor.PlayerProfile;
using MageSurvivor.Utils;

namespace MageSurvivor
{
    public interface IComposition : IDisposable
    {
        IProfile GetProfile();
        IViewFactory GetViewFactory();
        IConfigReader GetConfigReader();
        IProfileStorage GetProfileStorage();
        IResourceManager GetResourceManager();
        IGameConfiguration GetGameConfiguration();

        ViewManager GetViewManager();
        MenuPresenter GetMenuPresenter();
    }
}
