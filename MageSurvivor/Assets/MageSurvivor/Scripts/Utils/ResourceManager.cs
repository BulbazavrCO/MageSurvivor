using System;
using System.Collections.Generic;
using UnityEngine;

namespace MageSurvivor.Utils
{ 
    public class ResourceManager : IResourceManager
    {
        private Dictionary<Type, List<GameObject>> Pool;     

        public ResourceManager()
        {            
            Pool = new Dictionary<Type, List<GameObject>>();
        }

        public UnityEngine.Object GetAsset<TEnum>(TEnum resource)
            where TEnum : struct, IComparable, IConvertible, IFormattable
        {
            var type = typeof(TEnum);        
            var name = resource.ToString();

            var asset = GetAsset(type, name);

            return asset;
        }

        public GameObject GetPrefab<TEnum>(TEnum resource)
            where TEnum : struct, IComparable, IConvertible, IFormattable
        {
            var type = typeof(TEnum);           
            var name = resource.ToString();

            var go = (GameObject)GetAsset(type, name);

            return go;
        }

        public GameObject CreatePrefabInstance<TEnum>(TEnum resource)
            where TEnum : struct, IComparable, IConvertible, IFormattable
        {
            var type = typeof(TEnum);           
            var name = resource.ToString();

            var go = Instantiate(type, name);
            return go;
        }


        public TResult CreatePrefabInstance<TEnum, TResult>(TEnum resource)
            where TEnum : struct, IComparable, IConvertible, IFormattable
            where TResult : class
        {
            var type = typeof(TEnum);            
            var name = resource.ToString();

            var go = Instantiate(type, name);
            var component = go.GetComponent(typeof(TResult)) as TResult;
            return component;
        }        

        public GameObject GetFromPool<TEnum>(TEnum resource)
            where TEnum : struct, IComparable, IConvertible, IFormattable
        {
            var type = typeof(TEnum);

            var list = GetListPool(type);

            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];

                if (item.activeSelf == false)
                {
                    item.SetActive(true);
                    return item;
                }
            }
            
            var name = resource.ToString();           
            var poolItem = Instantiate(type, name);

            Pool[type].Add(poolItem);

            return poolItem;
        }

        public TResult GetFromPool<TEnum, TResult>(TEnum resource)
            where TEnum : struct, IComparable, IConvertible, IFormattable
            where TResult : class
        {            
            var poolItem = GetFromPool(resource);
            var component = poolItem.GetComponent<TResult>();

            return component;
        }        

        public void Warm<TEnum>(TEnum resource)
            where TEnum : struct, IComparable, IConvertible, IFormattable
        {
            var gameObject = GetFromPool(resource);
            gameObject.SetActive(false);
        }

        public void WarmAll<TEnum>()
            where TEnum : struct, IComparable, IConvertible, IFormattable
        {
            var type = typeof(TEnum);

            foreach (TEnum prefab in Enum.GetValues(type))
            {
                var gameObject = GetFromPool(prefab);
                gameObject.SetActive(false);
            }
        }

        public void Release<TEnum>(TEnum resource) where TEnum : struct, IComparable, IConvertible, IFormattable
        {
            var type = typeof(TEnum);
            Pool[type].Clear();
        }        

        public void ClearPool()
        {
            Pool.Clear();
        }       


        private List<GameObject> GetListPool(Type type)
        {
            if(Pool.ContainsKey(type) == false)
            {
                Pool.Add(type, new List<GameObject>());
            }

            return Pool[type];
        }

        private GameObject Instantiate(Type type, string name)
        {
            var template = GetAsset(type, name);
            var instance = GameObject.Instantiate(template) as GameObject;
            instance.SetActive(true);

            return instance;
        }

        private UnityEngine.Object GetAsset(Type type, string name)
        {
            var path = GetPathFromNamespace(type, name);
            var asset = Resources.Load<UnityEngine.Object>(path);

            if (asset == null)
                throw new UnityException("Can't load resource '" + path + "'");

            return asset;
        }     

        private string GetPathFromNamespace(Type type, string name)
        {
            string path = "";
            if (type.Namespace != null)
            {
                path = type.Namespace.Replace('.', '/') + @"/";
            }
            path += type.Name + @"/" + name;

            return path;
        }
    }
}
