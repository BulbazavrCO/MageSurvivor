using System.Collections.Generic;
using System.Linq;

namespace MageSurvivor.Configs
{
    public class GameConfiguration : IGameConfiguration
    {
        public ShopConfig ShopConfig { get; }

        private IReadOnlyDictionary<int, CharacterConfig> _charactersById;

        public GameConfiguration(ShopConfig shopConfig, List<CharacterConfig> characters)
        {
            ShopConfig = shopConfig;
            _charactersById = characters.ToDictionary(x => x.Id);
        }

        public CharacterConfig GetCharacter(int id)
        {
            return _charactersById[id];
        }       
    }
}
