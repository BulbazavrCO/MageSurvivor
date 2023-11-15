using System.Collections.Generic;

namespace MageSurvivor.Configs
{
    public class CharacterConfig
    {
        public int Id;        
        public string Name;
        public string Description;
        public ECharacters Character;

        public int MaxLevel;       
        public List<int> LevelsCost;
        public List<StatsConfig> Stats;
    }
}
