namespace retroLib
{
    /// <summary>
    /// Provides extension methods for safe object casting and parsing operations.
    /// </summary>
    public static class CastUtils
    {
        /// <summary>
        /// Attempts to cast an object to the specified type.
        /// </summary>
        /// <typeparam name="T">The target type to cast to</typeparam>
        /// <param name="obj">The object to cast</param>
        /// <param name="result">
        /// When this method returns a value and if the conversion is successful, it corresponds to the converted value
        /// /// Else it's the default value of the target type.
        /// </param>
        /// <returns>
        /// true or false (depends if the cast succeeds)
        /// </returns>
        public static bool TryCast<T>(this object obj, out T result)
        {
            if (obj is T t)
            {
                result = t;
                return true;
            }
            result = default!;
            return false;
        }

        /// <summary>
        /// Casts an object to the specified reference type or returns null if the cast fails.
        /// </summary>
        /// <typeparam name="T">The target reference type</typeparam>
        /// <param name="obj">The object to cast</param>
        /// <returns>
        /// It returns the casted object if it's successful, else it returns null.
        /// </returns>
        public static T? CastOrNull<T>(this object? obj) where T : class
        {
            return obj as T;
        }

        /// <summary>
        /// Casts an object to the specified type or returns a provided default value if the cast fails.
        /// </summary>
        /// <typeparam name="T">The target type</typeparam>
        /// <param name="obj">The object to cast</param>
        /// <param name="defaultValue">The value to return if the cast fails</param>
        /// <returns>
        /// It returns the casted value if successful, else it returns the specified default value.
        /// </returns>
        public static T CastOrDefault<T>(this object? obj, T defaultValue)
        {
            if (obj is T t)
                return t;
            return defaultValue;
        }

        /// <summary>
        /// Attempts to parse a string into the specified type and returns a default value if parsing fails.
        /// </summary>
        /// <typeparam name="T">The target type</typeparam>
        /// <param name="s">The string to parse</param>
        /// <param name="defaultValue">The value to return if parsing fails</param>
        /// <returns>
        /// It returns the parsed value if successful, else it returns the specified default value.
        /// </returns>
        public static T ParseOrDefault<T>(this string? s, T defaultValue)
        {
            if (string.IsNullOrWhiteSpace(s))
                return defaultValue;

            try
            {
                return (T)Convert.ChangeType(s, typeof(T));
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}
