using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;

namespace Meep.Tech.Text {

    /// <summary>
    /// Common Extensions for string types.
    /// </summary>
    public static partial class StringExtensions {

        #region Indentation

        /// <summary>
        /// Indent a block of text by a given amount.
        /// </summary>
        /// <param name="source">The text to indent.</param>
        /// <param name="count">The amount of indentation to add.</param>
        /// <param name="with">The indentation to use.</param>
        /// <param name="initial">Whether to indent the first line (appended to start of the text). (Defaults to true).</param>
        /// <param name="newline">Whether to add a newline before the text (and before optional initial indent). (Defaults to true).</param>
        public static string Indent(this string source, int count = 1, char with = '\t', bool initial = true, bool newline = true)
            => Indent(source, count, with.ToString(), initial, newline);

        /// <inheritdoc cref="Indent(string, int, char, bool, bool)"/>
        public static string Indent(this string source, int count = 1, string with = "\t", bool initial = true, bool newline = true) {
            string indents = string.Concat(Enumerable.Repeat(with, count));
            return $"{(newline ? '\n' : "")}{(initial ? indents : "")}{source.Replace("\n", "\n" + indents)}";
        }

        /// <inheritdoc cref="Indent(string, int, char, bool, bool)"/>
        public static string Indent(this string source, int count)
            => Indent(source, '\t', count);

        /// <inheritdoc cref="Indent(string, int, char, bool, bool)"/>
        public static string Indent(this string source)
            => Indent(source, '\t', 1);

        /// <inheritdoc cref="Indent(string, int, char, bool, bool)"/>
        public static string Indent(this string source, bool initial, bool newline)
            => Indent(source, 1, '\t', initial, newline);

        /// <inheritdoc cref="Indent(string, int, char, bool, bool)"/>
        public static string Indent(this string source, bool inline)
            => Indent(source, 1, '\t', inline);

        /// <inheritdoc cref="Indent(string, int, char, bool, bool)"/>
        public static string Indent(this string source, char with = '\t', int count = 1)
            => Indent(source, count, with);

        /// <inheritdoc cref="Indent(string, int, char, bool, bool)"/>
        public static string Indent(this string source, string with = "\t", int count = 1)
            => Indent(source, with, count);

        /// <summary>
        /// Dedent a block of text by a given amount.
        /// </summary>
        /// <param name="source"><inheritdoc cref="Indent(string, int, char, bool, bool)" path="/param[@name='text']"/></param>
        /// <param name="count">The amount of indentation to remove.</param>
        /// <param name="pattern"><inheritdoc cref="Indent(string, int, char, bool, bool)" path="/param[@name='with']"/></param>
        public static string Dedent(this string source, int count = 1, string pattern = "\t|  ")
            => Regex.Replace(source, $"^({pattern}){{{count}}}", "", RegexOptions.Multiline);

        /// <summary>
        /// Remove all indentation from a block of text.
        /// </summary>
        /// <param name="source">The text to remove all indentation from.</param>
        public static string Undent(this string source)
            => _Get_AllIndents_RegEx().Replace(source, "");

        /// <inheritdoc cref="Indent(string, int, string, bool, bool)"/>
        /// <param name="source"><inheritdoc cref="Indent(string, int, string, bool, bool)" path="/param[@name='text']"/></param>
        /// <param name="count"><inheritdoc cref="Indent(string, int, string, bool, bool)" path="/param[@name='count']"/></param>
        /// <param name="with"><inheritdoc cref="Indent(string, int, string, bool, bool)" path="/param[@name='indent']"/></param>
        /// <param name="inline">Determines if the indent should be inline or not (if false, a newline and indent are prepended). (Defaults to false)</param>
        public static string Indent(
            this string source,
            int count = 1,
            string with = "\t",
            bool inline = false
        ) => Indent(source, count, with, initial: !inline, newline: !inline);

        /// <inheritdoc cref="Indent(string, int, string, bool, bool)"/>
        /// <param name="source"><inheritdoc cref="Indent(string, int, string, bool, bool)" path="/param[@name='text']"/></param>
        /// <param name="count"><inheritdoc cref="Indent(string, int, string, bool, bool)" path="/param[@name='count']"/></param>
        /// <param name="with"><inheritdoc cref="Indent(string, int, string, bool, bool)" path="/param[@name='indent']"/></param>
        /// <param name="inline">Determines if the indent should be inline or not (if false, a newline and indent are prepended). (Defaults to false)</param>
        public static string Indent(
            this string source,
            int count = 1,
            char with = '\t',
            bool inline = false
        ) => Indent(source, count, with, initial: !inline, newline: !inline);

        /// <inheritdoc cref="Indent(string, int, string, bool, bool)"/>
        public static string Indent(this string source, int count = 1, char with = '\t')
            => Indent(source, count, with, inline: false);

        #endregion

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

        #endregion

        #region Generated Regex

        [GeneratedRegex(@"^\s+", RegexOptions.Multiline)]
        private static partial Regex _Get_AllIndents_RegEx();

        #endregion
    }
}