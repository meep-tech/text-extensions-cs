namespace Meep.Tech.Text {

  /// <summary>
  /// Common Extensions for string enumerables.
  /// </summary>
  public static class StringEnumerableExtensions {

    #region Join

    /// <inheritdoc cref="string.Join(char, object[])"/>
    /// <param name="source"><inheritdoc cref="string.Join(char, object[])" path="/param[@name='values']"/></param>
    /// <param name="separator"><inheritdoc cref="string.Join(char, object[])" path="/param[@name='separator']"/></param>
    /// <param name="transform">A function to transform each string before joining.</param>
    public static string Join<T>(this IEnumerable<T> source, char separator, Func<T, string> transform)
      => string.Join(separator, source.Select(transform));

    /// <inheritdoc cref="string.Join(string, IEnumerable{string})"/>
    /// <param name="source"><inheritdoc cref="string.Join(string, IEnumerable{string})" path="/param[@name='values']"/></param>
    /// <param name="separator"><inheritdoc cref="string.Join(string, IEnumerable{string})" path="/param[@name='separator']"/></param>
    /// <param name="transform">A function to transform each string before joining.</param>
    public static string Join<T>(this IEnumerable<T> source, string separator, Func<T, string> transform)
      => string.Join(separator, source.Select(transform));

    /// <inheritdoc cref="string.Join(char, object[])"/>
    public static string Join(this IEnumerable<string> strings, char separator)
      => string.Join(separator, strings);

    /// <inheritdoc cref="string.Join(string, IEnumerable{string})"/>
    public static string Join(this IEnumerable<string> strings, string separator)
      => string.Join(separator, strings);

    /// <inheritdoc cref="string.Join(char, object[])"/>
    /// <param name="strings"><inheritdoc cref="string.Join(char, object[])" path="/param[@name='values']"/></param>
    /// <param name="separator"><inheritdoc cref="string.Join(char, object[])" path="/param[@name='separator']"/></param>
    /// <param name="transform">A template to transform each string before joining. Use {0} as a placeholder for the string.</param>
    public static string Join(this IEnumerable<string> strings, char separator, FormattableString transform)
      => string.Join(separator, strings.Select(s => transform.Format.Replace("{0}", s)));

    /// <inheritdoc cref="string.Join(string, IEnumerable{string})"/>
    /// <param name="strings"><inheritdoc cref="string.Join(string, IEnumerable{string})" path="/param[@name='values']"/></param>
    /// <param name="separator"><inheritdoc cref="string.Join(string, IEnumerable{string})" path="/param[@name='separator']"/></param>
    /// <param name="transform">A template to transform each string before joining. Use {0} as a placeholder for the string.</param>
    public static string Join(this IEnumerable<string> strings, string separator, FormattableString transform)
      => string.Join(separator, strings.Select(s => transform.Format.Replace("{0}", s)));

    /// <inheritdoc cref="string.Join(char, object[])"/>
    /// <param name="strings"><inheritdoc cref="string.Join(char, object[])" path="/param[@name='values']"/></param>
    public static string Join(this IEnumerable<string> strings)
      => string.Join("", strings);

    /// <inheritdoc cref="string.Join(char, object[])"/>
    /// <param name="chars"><inheritdoc cref="string.Join(char, object[])" path="/param[@name='values']"/></param>
    public static string Join(this IEnumerable<char> chars)
      => string.Join("", chars);

    #endregion
  }
}