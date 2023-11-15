using System.Collections.Generic;

namespace MageSurvivor
{
    public class StatValue
    {
        public float CurrentValue { get; private set; }
        
        private float _baseValue;

        private List<Modifier> _modifiers;

        public StatValue(float value)
        {    
            _baseValue = value;
            CurrentValue = value;

            _modifiers = new List<Modifier>();
        }

        public void AddModifire(Modifier modifier)
        {
            _modifiers.Add(modifier);

            RecalculateValue();
        }

        public void RemoveModifire(Modifier modifier)
        {
            _modifiers.Remove(modifier);

            RecalculateValue();
        }

        private void RecalculateValue()
        {
            float standartValue = 0;
            float percentValue = 1;

            foreach(var modifire in _modifiers)
            {
                if(modifire.ModifireType == EModifireType.Percent)
                {
                    percentValue += modifire.Value;
                }
                else
                {
                    standartValue += modifire.Value;
                }
            }

            CurrentValue = (_baseValue + standartValue) * percentValue;
        }
    }
}
