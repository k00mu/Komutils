﻿// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

namespace Komutils
{
    public static class Helpers
    {
        public static void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}