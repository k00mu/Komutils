// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Komutils
{
    public static class Helpers
    {
        static readonly Dictionary<float, WaitForSeconds> WaitForSecondsDict = new(100, new FloatComparer());


        /// <summary>
        ///     Returns a WaitForSeconds object for the specified duration.
        /// </summary>
        /// <param name="seconds">The duration in seconds to wait.</param>
        /// <returns>A WaitForSeconds object.</returns>
        public static WaitForSeconds GetWaitForSeconds(float seconds)
        {
            if (seconds < 1f / Application.targetFrameRate) return null;

            if (!WaitForSecondsDict.TryGetValue(seconds, out WaitForSeconds forSeconds))
            {
                forSeconds = new WaitForSeconds(seconds);
                WaitForSecondsDict[seconds] = forSeconds;
            }

            return forSeconds;
        }


        /// <summary>
        ///     Quits the application.
        /// </summary>
        public static void QuitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }


#if UNITY_EDITOR
        /// <summary>
        ///     Clears the console log in the Unity Editor.
        /// </summary
        public static void ClearConsole()
        {
            var assembly = Assembly.GetAssembly(typeof(SceneView));
            var type = assembly.GetType("UnityEditor.LogEntries");
            var method = type.GetMethod("Clear");
            method?.Invoke(new object(), null);
        }
#endif


        class FloatComparer : IEqualityComparer<float>
        {
            public bool Equals(float x, float y)
            {
                return Mathf.Abs(x - y) <= Mathf.Epsilon;
            }


            public int GetHashCode(float obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}