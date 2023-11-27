namespace MageSurvivor
{
    public class UnitRepository : IUnitRepository
    {
        private IPlayer _player;

        public void AddPlayer(IPlayer player)
        {
            _player = player;
        }

        public IPlayer GetPlayer()
        {
            return _player;
        }
    }
}
