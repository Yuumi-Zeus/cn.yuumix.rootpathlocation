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

            // GettingStartedWindow.ShowWindow();
            instance.hasInitialized = true;
            instance.Save(true);
            Debug.Log("Saved to: " + GetFilePath());
        }

        [MenuItem("Tools/Odin Toolkits/Print HasInitialized")]
        public static void Log()
        {
            // 确保 instance 不为 null
            if (instance == null)
            {
                Debug.LogError("RootPathLocation instance is null!");
                return;
            }

            Debug.Log("RootPathLocation hasInitialized: " + JsonUtility.ToJson(instance, true));
        }
    }
}
