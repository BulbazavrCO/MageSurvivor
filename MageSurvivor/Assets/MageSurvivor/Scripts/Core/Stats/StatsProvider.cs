using System;
using System.Collections.Generic;
using MageSurvivor.Configs;

namespace MageSurvivor
{
    public class StatsProvider : IStats
    {
        private Dictionary<EStats, StatValue> _stats;

        public event Action StatsChanged = () => { };

        public StatsProvider()
        {
            _stats = new Dictionary<EStats, StatValue>();
        }

        public void Setup(List<StatsConfig> stats, int level)
        {
            level -= 1;

            foreach(var stat in stats)
            {
                var baseValue = stat.BaseValue;
                var gradeValue = stat.GaradeLevelValues == null || stat.GaradeLevelValues.Count < level ? 0 : stat.GaradeLevelValues[level];
                var value = baseValue + gradeValue;

                CreateStat(value, stat.Stat);
            }
        }

        public void Clear()
        {
            _stats.Clear();
        }

        public float GetStatValue(EStats type)
        {
            return _stats[type].CurrentValue;
        }

        public void AddModifier(Modifier modifier)
        {
            if (_stats.ContainsKey(modifier.Stat) == false)
                CreateStat(0, modifier.Stat);

            _stats[modifier.Stat].AddModifire(modifier);

            StatsChanged();
        }

        public void RemoveModifier(Modifier modifier)
        {
            _stats[modifier.Stat].RemoveModifire(modifier);

            StatsChanged();
        }

        private void CreateStat(float value, EStats stat)
        {
            var statValue = new StatValue(value);          

            _stats.Add(stat, statValue);
        }     
    }
}
