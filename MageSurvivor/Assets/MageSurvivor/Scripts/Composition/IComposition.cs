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
        IGameScenario GetGameScenario();
        IProfileStorage GetProfileStorage();
        IUnitRepository GetUnitRepository();
        IResourceManager GetResourceManager();
        IGameConfiguration GetGameConfiguration(); 
        
        ViewManager GetViewManager();
        PlayerCreator GetPlayerCreator();
        MenuPresenter GetMenuPresenter();
        ShopPresenter GetShopPresenter();
        BalancePresenter GetBalancePresenter();
        CharactersPresenter GetCharactersPresenter();
    }
}
