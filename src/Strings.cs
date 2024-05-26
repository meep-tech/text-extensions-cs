namespace Meep.Tech.Text {
    public static class StringExtensions {
        public static bool IsNullOrWhiteSpace(this string? s)
            => string.IsNullOrWhiteSpace(s);

        public static bool IsNullOrEmpty(this string? s)
            => string.IsNullOrEmpty(s);

        public static bool IsNotNullOrEmpty(this string? s)
            => !string.IsNullOrEmpty(s);

        public static bool IsNotNullOrWhiteSpace(this string? s)
            => !string.IsNullOrWhiteSpace(s);
    }
}
