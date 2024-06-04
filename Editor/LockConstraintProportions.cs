// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Komutils.Editor
{
    internal class LockConstraintProportions : MonoBehaviour
    {
        const BindingFlags BindingFlags =
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance;

        static readonly PropertyInfo ConstrainProportions;


        static LockConstraintProportions()
        {
            ConstrainProportions = typeof(Transform).GetProperty("constrainProportionsScale", BindingFlags);
        }


        [MenuItem("Edit/Toggle Constraint Proportions #&x")]
        public static void Toggle()
        {
            // Constraint Proportions lock for all versions including Unity 6
            foreach (UnityEditor.Editor activeEditor in ActiveEditorTracker.sharedTracker.activeEditors)
            {
                if (activeEditor.target is not Transform target) continue;

                var currentValue = (bool)ConstrainProportions.GetValue(target, null);
                ConstrainProportions.SetValue(target, !currentValue, null);
            }

            ActiveEditorTracker.sharedTracker.ForceRebuild();
        }


        [MenuItem("Edit/Toggle Constraint Proportions #&x", true)]
        public static bool Valid()
        {
            return ActiveEditorTracker.sharedTracker.activeEditors.Length != 0;
        }
    }
}