using System;
using System.Collections.Generic;
using System.Linq;

namespace MageSurvivor.PlayerProfile
{
    public class GameConfiguration : IGameConfiguration
    {
        public ShopConfig ShopConfig { get; }

        private IReadOnlyDictionary<int, CharacterConfig> _characters;

        public GameConfiguration(ShopConfig shopConfig, List<CharacterConfig> characters)
        {
            ShopConfig = shopConfig;
            _characters = characters.ToDictionary(x => x.Id);
        }

        public CharacterConfig GetCharacter(int id)
        {
            return _characters[id];
        }
    }
}
