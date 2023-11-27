using System;

namespace MageSurvivor
{
    public interface IMenuView : IView
    {
        event Action PlayButtonClicked;
        event Action ShopButtonClicked;
        event Action CharactersButtonClicked;
    }
}
