// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEditor;

namespace Komutils
{
    public static class Helpers
    {
        public static void QuitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}