using UnityEngine;

namespace Assets.CodeBase
{
    public static class Extensions
    {
        public static string ToJson<T>(this T obj) => JsonUtility.ToJson(obj);
        public static T FromJson<T>(this string obj) => JsonUtility.FromJson<T>(obj);
    }
}
