namespace Meep.Tech.Text {

  /// <summary>
  /// Simple global-level logging utility.
  /// </summary>
  public static class Log {

    /// <summary>
    /// Writes a value to the console if the DEBUG flag is set.
    /// </summary>
    public static void Debug(this object? value) =>
#if DEBUG
      Console.WriteLine(value);
#endif
  }
}