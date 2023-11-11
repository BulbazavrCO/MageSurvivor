using System;
using System.Collections.Generic;

namespace MageSurvivor.PlayerProfile
{
    public interface IProfile 
    {
        event Action BalanceChanged;
        event Action CharactersChanged;

        void SetState(ProfileState profileState);

        void BuyCharacter(int id);
        void LevelUpCharacter(int id);
    }
}
