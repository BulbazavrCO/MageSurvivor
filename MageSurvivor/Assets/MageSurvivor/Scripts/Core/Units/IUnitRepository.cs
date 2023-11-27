namespace MageSurvivor
{
    public interface IUnitRepository
    {
        void AddPlayer(IPlayer player);

        IPlayer GetPlayer();
    }
}
