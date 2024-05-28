namespace Meep.Tech.Text {
    public static class CharExtensions {
        public static bool IsWhiteSpaceOrNull(this char c)
            => c is '\0' || char.IsWhiteSpace(c);

        public static bool IsWhiteSpaceOrNull(this char? c)
            => c is null || c.Value is '\0' || char.IsWhiteSpace(c.Value);

        public static bool IsWhiteSpace(this char c)
            => char.IsWhiteSpace(c);

        public static bool IsLetter(this char c)
            => char.IsLetter(c);

        public static bool IsDigit(this char c)
            => char.IsDigit(c);

        public static bool IsLetterOrDigit(this char c)
            => char.IsLetterOrDigit(c);
    }
}
