using System;
using System.Collections.Generic;

namespace MageSurvivor
{
    public interface IShopView : IView
    {
        event Action<int> CoinsBuyClicked;
        event Action<int> CharacterBuyClicked;       

       
        void SetCharacterProducts(List<CharacterProductInfo> characterProducts);
    }
}
