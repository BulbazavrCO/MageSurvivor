namespace MageSurvivor
{
    public interface IStats
    {
        public float GetStatValue(EStats type);       

        public void AddModifier(Modifier modifier);       
        public void RemoveModifier(Modifier modifier); 
    }
}
