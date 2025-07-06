using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace Yuumix.Editor.Core
{
    public class GettingStartedWindow : OdinEditorWindow
    {
        [MenuItem("Tools/Odin Toolkits/Getting Started")]
        public static void ShowWindow()
        {
            var window = GetWindow<GettingStartedWindow>();
            window.titleContent = new GUIContent("Getting Started");
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(600, 800);
            window.Show();
            window.minSize = new Vector2(500, 500);
        }
    }
}
