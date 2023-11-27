using System;
using UnityEngine;

namespace MageSurvivor
{
    public interface IUnit : IStats
    {
        event Action Died;

        Transform Pivot { get; }

        bool IsAlive();
    }
}
