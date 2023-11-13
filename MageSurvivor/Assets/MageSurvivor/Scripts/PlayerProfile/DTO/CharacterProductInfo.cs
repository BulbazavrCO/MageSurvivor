namespace MageSurvivor
{
    public struct CharacterProductInfo
    {
        public readonly int Id;
        public readonly string Name;
        public readonly int Price;

        public CharacterProductInfo(int id, string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
