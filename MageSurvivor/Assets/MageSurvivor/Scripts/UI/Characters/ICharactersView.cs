using System;
using System.Collections.Generic;

namespace MageSurvivor
{
    public interface ICharactersView : IView
    {
        event Action BackButtonClicked;
        event Action<int> InfoCharacterClicked;
        event Action<int> SelectCharaterClicked;

        void SetCharacters(List<CharacterInfo> characters);
    }
}
