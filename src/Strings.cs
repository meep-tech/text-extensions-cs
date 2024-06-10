using System.Text;

namespace Meep.Tech.Text {

    /// <summary>
    /// Common Extensions for string types.
    /// </summary>
    public static class StringExtensions {

        /// <inheritdoc cref="string.IsNullOrWhiteSpace(string)"/>
        public static bool IsNullOrWhiteSpace(this string? s)
            => string.IsNullOrWhiteSpace(s);

        /// <inheritdoc cref="string.IsNullOrEmpty(string)"/>
        public static bool IsNullOrEmpty(this string? s)
            => string.IsNullOrEmpty(s);

        /// <inheritdoc cref="string.IsNullOrEmpty(string)"/>
        public static bool IsNotNullOrEmpty(this string? s)
            => !string.IsNullOrEmpty(s);

        /// <inheritdoc cref="string.IsNullOrWhiteSpace(string)"/>
        public static bool IsNotNullOrWhiteSpace(this string? s)
            => !string.IsNullOrWhiteSpace(s);

        /// <summary>
        ///  Converts a string to snake_case 
        ///     (while maintaining the existing lower and upper case characters).
        /// </summary>
        public static string ToSnakeCase(this string text) {
            ArgumentNullException.ThrowIfNull(text);

            if(text.Length < 2) {
                return text;
            }

            StringBuilder result = new();
            result.Append(text[0]);
            foreach(char c in text.Skip(1)) {
                if(char.IsUpper(c)) {
                    result.Append('_');
                }

                result.Append(c);
            }

            return result.ToString();
        }
    }
}
