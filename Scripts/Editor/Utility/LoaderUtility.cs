using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace NaughtyAttributes.Editor
{
    public static class LoaderUtility
    {
        public static void LoadFirstAssetIfNull<T>(ref T asset, string searchString, bool log = true) where T : Object
        {
            if (asset != null)
                return;

            asset = GetFirstAsset<T>(searchString, log);
        }

        public static T GetFirstAsset<T>(string searchString, bool log = true) where T : Object
        {
            return GetFirstAsset(typeof(T), searchString, log) as T;
        } 
        
        internal static Object GetFirstAsset(Type type,string searchString, bool log)
        {
            var guids = AssetDatabase.FindAssets(searchString);
            if (guids.Length == 0 && log)
            {
                Debug.LogWarning($"Can't find {type.Name} by search string {searchString}");
                return null;
            }
            
            var path = AssetDatabase.GUIDToAssetPath(guids[0]);
            var asset = AssetDatabase.LoadAssetAtPath(path, type);
            if (guids.Length > 1 && asset != null && log)
                Debug.LogWarning($"Found several {asset.GetType().Name} by search string {searchString}");
            return asset;
        } 
    }
}