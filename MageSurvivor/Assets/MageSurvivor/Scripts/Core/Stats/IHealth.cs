using System;

namespace MageSurvivor
{
    public interface IHealth
    {
        event Action Dying;
        event Action HealthChanged;

        float HealthPoints { get; }

        void Setup();
        void Hit(float damage);
        void Heal(float value);
        void StatsChanged();

        float GetHealthPercent();
    }
}
