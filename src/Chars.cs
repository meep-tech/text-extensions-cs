namespace Meep.Tech.Text {

    /// <summary>
    /// Common Extensions for char types.
    /// </summary>
    public static class CharExtensions {

        /// <summary>
        /// Determines if the character is a whitespace character or null.
        /// </summary>
        public static bool IsWhiteSpaceOrNull(this char c)
            => c is '\0'
            || char.IsWhiteSpace(c);

        /// <inheritdoc cref="IsWhiteSpaceOrNull(char)"/>
        public static bool IsWhiteSpaceOrNull(this char? c)
            => c is null
            || c.Value is '\0'
            || char.IsWhiteSpace(c.Value);

        /// <inheritdoc cref="char.IsWhiteSpace(char)"/>
        public static bool IsWhiteSpace(this char c)
            => char.IsWhiteSpace(c);

        /// <inheritdoc cref="char.IsLetter(char)"/>
        public static bool IsLetter(this char c)
            => char.IsLetter(c);

        /// <inheritdoc cref="char.IsUpper(char)"/>
        public static bool IsUpper(this char c)
            => char.IsUpper(c);

        /// <inheritdoc cref="char.IsLower(char)"/>
        public static bool IsLower(this char c)
            => char.IsLower(c);

        /// <inheritdoc cref="char.IsDigit(char)"/>
        public static bool IsDigit(this char c)
            => char.IsDigit(c);

        /// <inheritdoc cref="char.IsLetterOrDigit(char)"/>
        public static bool IsLetterOrDigit(this char c)
            => char.IsLetterOrDigit(c);

        /// <summary>
        /// Determines if the character is a newline character.
        /// </summary>
        public static bool IsNewLine(this char c)
            => c is '\n'
            || c is '\r';

        /// <summary>
        /// Determines if the character is a newline character or null/eof.
        /// </summary> 
        public static bool IsEndOfLine(this char c)
            => c is '\n'
            || c is '\r'
            || c is '\0';

        /// <summary>
        /// Determines if the character is a newline character or null/eof.
        /// </summary> 
        public static bool IsEndOfLine(this char? c)
            => c is null
            || c is '\n'
            || c is '\r'
            || c is '\0';
    }
}
