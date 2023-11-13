using System.Collections.Generic;

namespace MageSurvivor.PlayerProfile
{
    public class CharacterConfig
    {
        public int Id;
        public string Name;
        public string Description;

        public int MaxLevel;       
        public List<int> LevelsCost;
    }
}
