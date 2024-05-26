namespace Meep.Tech.Text {
    public static class CharExtensions {
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
