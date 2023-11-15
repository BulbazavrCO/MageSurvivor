using System;

namespace MageSurvivor
{
    public class Health : IHealth
    {
        private float _healthPoints;
        private float _maxHealthPoints;

        private StatsProvider _statsProvider;

        public float HealthPoints => throw new NotImplementedException();

        public event Action Dying = () => { };

        public Health(StatsProvider statsProvider)
        {
            _statsProvider = statsProvider;
        }

        public void Setup()
        {         
            _healthPoints = _statsProvider.GetStatValue(EStats.Health);
            _maxHealthPoints = _healthPoints;

            _statsProvider.StatsChanged += RecalculateHeath;
        }

        public void Heal(float value)
        {
            if (value <= 0)
                return;

            _healthPoints += value;

            if (_healthPoints > _maxHealthPoints)
            {
                _healthPoints = _maxHealthPoints;
            }
        }

        public void Hit(float damage)
        {
            if (damage <= 0)
                return;

            _healthPoints -= damage;

            if(_healthPoints <= 0)
            {
                _healthPoints = 0;
                Dying();

                _statsProvider.StatsChanged -= RecalculateHeath;
            }
        }       

        private void RecalculateHeath()
        {
            var newMaxHealth = _statsProvider.GetStatValue(EStats.Health);
            var coef = _maxHealthPoints / newMaxHealth;
            _healthPoints *= 1 / coef; 
        }
    }
}
