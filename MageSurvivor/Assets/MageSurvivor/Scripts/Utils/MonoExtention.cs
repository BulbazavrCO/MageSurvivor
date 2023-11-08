using UnityEngine;

namespace MageSurvivor.Utils
{
    public class MonoExtention 
    {
        public static T MakeComponent<T>() where T : Component
        {
            var obj = new GameObject();
            obj.name = typeof(T).Name;
            var component = obj.AddComponent<T>();

            return component;
        }
    }
}
