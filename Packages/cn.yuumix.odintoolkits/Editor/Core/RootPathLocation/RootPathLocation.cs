using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Yuumix.Editor.Core
{
    [FilePath("OdinToolkitsEditorSettings/RootPathLocation.meta", FilePathAttribute.Location.ProjectFolder)]
    public class RootPathLocation : ScriptableSingleton<RootPathLocation>
    {
        public bool hasInitialized;

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

            // 延迟到下一帧执行，确保 GUI 系统已初始化
            EditorApplication.delayCall += ShowWindowDelayed;
        }

        static void ShowWindowDelayed()
        {
            EditorApplication.delayCall -= ShowWindowDelayed;

            // 防止有人在 Play 模式下导入包
            if (EditorApplication.isPlayingOrWillChangePlaymode)
            {
                return;
            }

            GettingStartedWindow.ShowWindow();
            instance.hasInitialized = true;
            instance.Save(true);
            Debug.Log("Saved to: " + GetFilePath());
        }

        [MenuItem("Tools/Odin Toolkits/Print HasInitialized")]
        public static void Log()
        {
            if (!instance)
            {
                Debug.LogError("RootPathLocation instance is null!");
                return;
            }

            Debug.Log("RootPathLocation hasInitialized: " + JsonUtility.ToJson(instance, true));
        }
    }
}
