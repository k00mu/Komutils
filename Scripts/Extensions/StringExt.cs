// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System;

namespace Komutils.Extensions
{
    public static class StringExt
    {
        /// <summary>Checks if a string is Null or white space</summary>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }


        /// <summary>Checks if a string is Null or empty</summary>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }


        /// <summary>Checks if a string contains null, empty or white space.</summary>
        public static bool IsBlank(this string value)
        {
            return value.IsNullOrWhiteSpace() || value.IsNullOrEmpty();
        }


        /// <summary>Checks if a string is null and returns an empty string if it is.</summary>
        public static string OrEmpty(this string value)
        {
            return value ?? string.Empty;
        }


        /// <summary>
        ///     Shortens a string to the specified maximum length. If the string's length
        ///     is less than the maxLength, the original string is returned.
        /// </summary>
        public static string Shorten(this string value, int maxLength)
        {
            if (value.IsBlank()) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }


        /// <summary>Slices a string from the start index to the end index.</summary>
        /// <returns>The sliced string.</returns>
        public static string Slice(this string value, int startIndex, int endIndex)
        {
            if (value.IsBlank()) throw new ArgumentNullException(nameof(value), "Value cannot be null or empty.");

            if (startIndex < 0 || startIndex > value.Length - 1)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            // If the end index is negative, it will be counted from the end of the string.
            endIndex = endIndex < 0 ? value.Length + endIndex : endIndex;

            if (endIndex < 0 || endIndex < startIndex || endIndex > value.Length)
                throw new ArgumentOutOfRangeException(nameof(endIndex));

            return value.Substring(startIndex, endIndex - startIndex);
        }
    }
}