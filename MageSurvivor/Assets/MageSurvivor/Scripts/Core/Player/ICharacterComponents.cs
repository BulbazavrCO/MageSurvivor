namespace MageSurvivor
{
    public interface ICharacterComponents : IComponents
    {        
        BonusHolder BonusHolder { get; }
        
        void AddBonusHolder(BonusHolder bonusHolder);
    }
}
