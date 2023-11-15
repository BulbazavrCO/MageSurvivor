namespace MageSurvivor.Configs
{
    public interface IGameConfiguration
    {
        ShopConfig ShopConfig { get; }
        CharacterConfig GetCharacter(int id);      
    }
}
