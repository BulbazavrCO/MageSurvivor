using System;
using UnityEngine;

namespace MageSurvivor.Utils
{
    public interface IResourceManager
    {
        UnityEngine.Object GetAsset<TEnum>(TEnum resource)
             where TEnum : struct, IComparable, IConvertible, IFormattable;

        GameObject GetPrefab<TEnum>(TEnum resource)
            where TEnum : struct, IComparable, IConvertible, IFormattable;

        GameObject CreatePrefabInstance<TEnum>(TEnum resource)
            where TEnum : struct, IComparable, IConvertible, IFormattable;

        TResult CreatePrefabInstance<TEnum, TResult>(TEnum resource)
            where TEnum : struct, IComparable, IConvertible, IFormattable
            where TResult : class;
        

        GameObject GetFromPool<TEnum>(TEnum resource)
            where TEnum : struct, IComparable, IConvertible, IFormattable;

        TResult GetFromPool<TEnum, TResult>(TEnum resource)
            where TEnum : struct, IComparable, IConvertible, IFormattable
            where TResult : class;
        

        void WarmAll<TEnum>()
            where TEnum : struct, IComparable, IConvertible, IFormattable;

        void Warm<TEnum>(TEnum resource)
            where TEnum : struct, IComparable, IConvertible, IFormattable;


        void Release<TEnum>(TEnum resource)
            where TEnum : struct, IComparable, IConvertible, IFormattable;       
       
        void ClearPool();
    }
}
