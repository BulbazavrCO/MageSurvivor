using System;
using UnityEngine;

namespace MageSurvivor
{
    public interface IPlayer : IStats
    {
        event Action Died;

        void Setup(CharacterInfo character);
        bool IsAlive();
        void Move(Vector2 direction);
        void Stop();
    }
}
