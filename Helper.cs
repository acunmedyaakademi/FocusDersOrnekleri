namespace Relations;

public static class Helper
{
    private static bool _isColored = true;
    public static void WriteLine(string message)
    {
        Console.ForegroundColor = _isColored ? ConsoleColor.DarkGray : ConsoleColor.White;
        Console.WriteLine(message);
        Console.ResetColor();
        _isColored = !_isColored;
    }
}