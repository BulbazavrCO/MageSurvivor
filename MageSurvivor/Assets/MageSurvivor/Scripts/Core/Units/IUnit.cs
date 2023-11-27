using System;
using UnityEngine;

namespace MageSurvivor
{
    public interface IUnit : IStats
    {
        event Action Died;
        event Action HealthChanged;

        Transform Pivot { get; }

        bool IsAlive();
        void TakeDamage(float value);
    }
}
