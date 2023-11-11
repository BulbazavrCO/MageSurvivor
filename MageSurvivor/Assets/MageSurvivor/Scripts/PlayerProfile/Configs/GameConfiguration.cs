using System;
using System.Collections.Generic;
using System.Linq;

namespace MageSurvivor.PlayerProfile
{
    public class GameConfiguration : IGameConfiguration
    {
        private IReadOnlyDictionary<int, CharacterConfig> _characters;

        public GameConfiguration(List<CharacterConfig> characters)
        {
            _characters = characters.ToDictionary(x => x.Id);
        }

        public CharacterConfig GetCharacter(int id)
        {
            return _characters[id];
        }
    }
}
