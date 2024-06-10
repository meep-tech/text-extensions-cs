namespace Meep.Tech.Text {

    /// <summary>
    /// Common Extensions for char types.
    /// </summary>
    public static class CharExtensions {

        /// <inheritdoc cref="IsWhiteSpaceOrNull(char)"/>
        public static bool IsWhiteSpaceOrNull(this char c)
            => c is '\0'
            || char.IsWhiteSpace(c);

        /// <inheritdoc cref="IsWhiteSpaceOrNull(char)"/>
        public static bool IsWhiteSpaceOrNull(this char? c)
            => c is null
            || c.Value is '\0'
            || char.IsWhiteSpace(c.Value);

        /// <inheritdoc cref="IsWhiteSpaceOrNull(char)"/>
        public static bool IsWhiteSpace(this char c)
            => char.IsWhiteSpace(c);

        /// <inheritdoc cref="IsWhiteSpaceOrNull(char)"/>
        public static bool IsLetter(this char c)
            => char.IsLetter(c);

        /// <inheritdoc cref="IsWhiteSpaceOrNull(char)"/>
        public static bool IsDigit(this char c)
            => char.IsDigit(c);

        /// <inheritdoc cref="IsWhiteSpaceOrNull(char)"/>
        public static bool IsLetterOrDigit(this char c)
            => char.IsLetterOrDigit(c);
    }
}
