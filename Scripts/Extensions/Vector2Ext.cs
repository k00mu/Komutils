// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;

namespace Komutils.Extensions
{
    public static class Vector2Ext
    {
        /// <summary>
        ///     Sets any values of the Vector2
        /// </summary>
        public static Vector2 With(this Vector2 v, float? x = null, float? y = null)
        {
            return new Vector2(x ?? v.x, y ?? v.y);
        }


        /// <summary>
        ///     Adds to any values of the Vector2
        /// </summary>
        public static Vector2 Add(this Vector2 v, float x = 0, float y = 0)
        {
            return new Vector2(v.x + x, v.y + y);
        }


        /// <summary>
        ///     Checks if the current Vector2 is in the given range from the target Vector2
        /// </summary>
        /// <param name="current">The current Vector2 position</param>
        /// <param name="target">The Vector2 position to compare against</param>
        /// <param name="range">The range value to compare against</param>
        /// <returns>True if the current Vector2 is in the given range from the target Vector2, false otherwise</returns>
        public static bool InRangeOf(this Vector2 current, Vector2 target, float range)
        {
            return (current - target).sqrMagnitude <= range * range;
        }


        /// <summary>
        ///     Computes a random point in an annulus (a ring-shaped area) based on minimum and
        ///     maximum radius values around a central Vector2 point (origin).
        /// </summary>
        /// <param name="origin">The center Vector2 point of the annulus.</param>
        /// <param name="minRadius">Minimum radius of the annulus.</param>
        /// <param name="maxRadius">Maximum radius of the annulus.</param>
        /// <returns>A random Vector2 point within the specified annulus.</returns>
        public static Vector2 RandomPointInAnnulus(this Vector2 origin, float minRadius, float maxRadius)
        {
            var angle = Random.value * Mathf.PI * 2f;
            var direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // Squaring and then square-rooting radii to ensure uniform distribution within the annulus
            var minRadiusSquared = minRadius * minRadius;
            var maxRadiusSquared = maxRadius * maxRadius;
            var distance = Mathf.Sqrt(Random.value * (maxRadiusSquared - minRadiusSquared) + minRadiusSquared);

            // Calculate the position vector
            Vector2 position = direction * distance;
            return origin + position;
        }
    }
}