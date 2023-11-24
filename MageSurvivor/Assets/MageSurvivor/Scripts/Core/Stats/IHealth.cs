using System;

namespace MageSurvivor
{
    public interface IHealth
    {
        event Action Dying;

        float HealthPoints { get; }

        void Setup();
        void Hit(float damage);
        void Heal(float value);
        void StatsChanged();
    }
}
