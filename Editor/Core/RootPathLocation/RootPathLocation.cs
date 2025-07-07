using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Yuumix.OdinToolkits.Editor.Core;
using Yuumix.YuumixEditor;

namespace Yuumix.Editor.Core
{
    internal enum OdinToolkitsMode
    {
        EmbeddedPackage = 0,
        Plugin = 1,
        PackageCache = 2
    }

    [FilePath("OdinToolkitsEditorSettings/RootPathLocation.asset", FilePathAttribute.Location.ProjectFolder)]
    public sealed class RootPathLocation : ScriptableSingleton<RootPathLocation>
    {
        [SerializeField]
        bool hasInitialized;

        [SerializeField]
        OdinToolkitsMode currentMode;

        [SerializeField]
        RootLookup rootLookup;

        [InitializeOnLoadMethod]
        public static void FirstImport()
        {
            // 确保 instance 不为 null
            if (!instance)
            {
                Debug.LogError("RootPathLocation instance is null!");
                return;
            }

            if (instance.hasInitialized)
            {
                return;
            }

            instance.rootLookup = ScriptableObjectEditorUtil.GetAssetDeleteExtra<RootLookup>();
            if (!instance.rootLookup)
            {
                Debug.Log("RootLookup 获取失败");
            }
            // 延迟到下一帧执行，确保 GUI 系统已初始化
            EditorApplication.delayCall += ShowWindowDelayed;
        }

        static OdinToolkitsMode GetOdinToolkitsMode()
        {
            var assetDatabasePath = AssetDatabase.GetAssetPath(instance);
            var filePath = GetFilePath();
            if (filePath != assetDatabasePath)
            {
                Debug.LogError("此时 GetFilePath() 和 AssetDatabase.GetAssetPath(instance) 的值不一样");
            }

            if (filePath == assetDatabasePath)
            {
                if (assetDatabasePath.StartsWith("Packages/"))
                {
                    return OdinToolkitsMode.EmbeddedPackage;
                }
            }

            return OdinToolkitsMode.EmbeddedPackage;
        }

        static void ShowWindowDelayed()
        {
            // 防止用户在 Play 模式下导入包
            if (EditorApplication.isPlayingOrWillChangePlaymode)
            {
                return;
            }

            EditorApplication.delayCall -= ShowWindowDelayed;
            GettingStartedWindow.ShowWindow();
            instance.hasInitialized = true;
            instance.Save(true);
            Debug.Log("Saved to: " + GetFilePath());
        }

        [MenuItem("Tools/Odin Toolkits/Log Info")]
        public static void LogInfo()
        {
            if (!instance)
            {
                Debug.LogError("RootPathLocation instance is null!");
                return;
            }

            Debug.Log("RootPathLocation hasInitialized: " + JsonUtility.ToJson(instance, true));
            Debug.Log("RootPathLocation currentMode: " + EditorJsonUtility.ToJson(instance, true));
        }

        [MenuItem("Tools/Odin Toolkits/Log Path")]
        public static void LogPath()
        {
            Debug.Log("使用 File.GetFullPath 获取 RootPathLocation 文件路径: " + GetFilePath());
            Debug.Log("使用 AssetDatabase 获取 RootPathLocation 文件路径: " + AssetDatabase.GetAssetPath(instance));
        }

        [MenuItem("Tools/Odin Toolkits/Get Mode")]
        public static void GetMode()
        {
            Debug.Log("当前模式: " + GetOdinToolkitsMode());
        }

        [MenuItem("Tools/Odin Toolkits/Get RootLookupPath")]
        public static void GetRootLookupPath()
        {
            var path = ScriptableObjectEditorUtil.GetAssetPath<RootLookup>();
            Debug.Log("RootLookup Asset 路径为: " + path);
        }
    }
}
