namespace MageSurvivor
{
    public struct CharacterInfo
    {
        public readonly int ID;
        public readonly int Level;
        public readonly string Name;
        public readonly string Description;

        public readonly bool IsSelected;
        public readonly bool IsMaxLevel;
        public readonly int CoinsToLevelUp;

        public CharacterInfo(int id, int level, string name, string description, bool isMaxLevel, bool isSelected, int coinsToLevelUp)
        {
            ID = id;
            Level = level;
            Name = name;
            Description = description;
            IsMaxLevel = isMaxLevel;
            IsSelected = isSelected;
            CoinsToLevelUp = coinsToLevelUp;
        }
    }
}
