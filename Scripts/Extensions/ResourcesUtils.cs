// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;
#if ENABLED_UNITY_RENDER_PIPELINES
using UnityEngine.Rendering;
#endif

namespace Komutils.Extensions
{
    public static class ResourcesUtils
    {
#if ENABLED_UNITY_RENDER_PIPELINES
        /// <summary>
        ///     Load volume profile from given path.
        /// </summary>
        /// <param name="path">Path from where volume profile should be loaded.</param>
        public static void LoadVolumeProfile(this Volume volume, string path)
        {
            var profile = Resources.Load<VolumeProfile>(path);
            volume.profile = profile;
        }
#endif
    }
}