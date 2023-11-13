using System.Collections.Generic;

namespace MageSurvivor.PlayerProfile
{
    public class ProfileState
    {
        public ShopState ShopState;
        public PlayerState PlayerState;        
        public Dictionary<int, CharacterState> Characters;
    }
}
