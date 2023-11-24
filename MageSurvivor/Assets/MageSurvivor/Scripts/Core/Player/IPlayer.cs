using System;

namespace MageSurvivor
{
    public interface IPlayer : IStats
    {
        event Action Died;

        void Setup(CharacterInfo character);
        bool IsAlive();       
    }
}
