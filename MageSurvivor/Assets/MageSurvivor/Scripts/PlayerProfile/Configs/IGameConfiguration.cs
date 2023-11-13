namespace MageSurvivor.PlayerProfile
{
    public interface IGameConfiguration
    {
        ShopConfig ShopConfig { get; }
        CharacterConfig GetCharacter(int id);     
    }
}
