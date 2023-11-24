using System;
using MageSurvivor.PlayerProfile;
using MageSurvivor.Utils;
using MageSurvivor.Configs;

namespace MageSurvivor
{
    public interface IComposition : IDisposable
    {
        IInput GetInput();
        IProfile GetProfile();
        IViewFactory GetViewFactory();
        IConfigReader GetConfigReader();
        IProfileStorage GetProfileStorage();
        IResourceManager GetResourceManager();
        IGameConfiguration GetGameConfiguration();       

        GameCamera GetGameCamera();
        ViewManager GetViewManager();
        MenuPresenter GetMenuPresenter();
        ShopPresenter GetShopPresenter();
        BalancePresenter GetBalancePresenter();
        CharactersPresenter GetCharactersPresenter();
    }
}
