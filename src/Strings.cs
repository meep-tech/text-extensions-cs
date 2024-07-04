using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Meep.Tech.Text {

    /// <summary>
    /// Common Extensions for string types.
    /// </summary>
    public static class StringExtensions {

        #region Validation

        /// <summary>
        /// Determines if the string is entirely upper case.
        /// </summary>
        public static bool IsUpper(this string text) {
            ArgumentNullException.ThrowIfNull(text);

            foreach(char c in text) {
                if(!char.IsUpper(c)) {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines if the string is entirely lower case.
        /// </summary>
        public static bool IsLower(this string text) {
            ArgumentNullException.ThrowIfNull(text);

            foreach(char c in text) {
                if(!char.IsLower(c)) {
                    return false;
                }
            }

            return true;
        }

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

        #endregion

        #region Case Conversion

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

        #endregion

        #region Try Get Char At

        /// <summary>
        ///  Attempts to get the character at the specified index.
        /// </summary>
        /// <param name="text">The text to get the character from.</param>
        /// <param name="index">The index of the character to get.</param>
        /// <param name="c">The character at the specified index, if it exists.</param>
        /// <returns>True if the character exists; otherwise, false.</returns>
        public static bool TryGetCharAt(this string text, int index, [NotNullWhen(true)] out char? c) {
            if(index < 0 || index >= text.Length) {
                c = null;
                return false;
            }

            c = text[index];
            return true;
        }
    }

    #endregion

}