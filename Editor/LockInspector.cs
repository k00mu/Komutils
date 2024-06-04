// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Komutils.Editor
{
    /// <summary>
    ///     Toggles the Inspector lock state and the Constraint Proportions lock state.
    /// </summary>
    internal class LockInspector : MonoBehaviour
    {
        const BindingFlags BindingFlags =
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance;

        static readonly MethodInfo FlipLocked;


        static LockInspector()
        {
            // Cache static MethodInfo and PropertyInfo for performance
#if UNITY_2022_3_OR_NEWER
            Type editorLockTrackerType =
                typeof(EditorGUIUtility).Assembly.GetType("UnityEditor.EditorGUIUtility+EditorLockTracker");
            FlipLocked = editorLockTrackerType.GetMethod("FlipLocked", BindingFlags);
#endif
        }


        [MenuItem("Edit/Toggle Inspector Lock #&z")]
        public static void Toggle()
        {
#if UNITY_2022_3_OR_NEWER
            // New approach for Unity 2023.2 and above, including Unity 6
            Type inspectorWindowType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.InspectorWindow");

            foreach (Object inspectorWindow in Resources.FindObjectsOfTypeAll(inspectorWindowType))
            {
                var lockTracker =
                    inspectorWindowType.GetField("m_LockTracker", BindingFlags)?.GetValue(inspectorWindow);
                FlipLocked?.Invoke(lockTracker, new object[] { });
            }
#else
            // Old approach for Unity versions before 2023.2
            ActiveEditorTracker.sharedTracker.isLocked = !ActiveEditorTracker.sharedTracker.isLocked;
#endif
            ActiveEditorTracker.sharedTracker.ForceRebuild();
        }


        [MenuItem("Edit/Toggle Inspector Lock #&z", true)]
        public static bool Valid()
        {
            return ActiveEditorTracker.sharedTracker.activeEditors.Length != 0;
        }
    }
}