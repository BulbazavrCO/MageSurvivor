namespace MageSurvivor
{
    public interface IProfileStorage
    {
        //If you need, can be change to async
        void Save();
        void Load();
    }
}