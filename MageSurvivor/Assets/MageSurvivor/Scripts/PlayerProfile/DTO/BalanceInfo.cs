namespace MageSurvivor
{
    public struct BalanceInfo
    {
        public readonly int Gems;
        public readonly int Coins;

        public BalanceInfo(int gems, int coins)
        {
            Gems = gems;
            Coins = coins;
        }
    }
}
