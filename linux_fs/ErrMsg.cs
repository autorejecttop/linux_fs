class ERRMSG {
    public static void FILE_NOT_FOUND(String arg) {
        Console.WriteLine($"{arg}\" <- FILE NOT FOUND ");
    }

    public static void DIR_NOT_FOUND(String arg) {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{arg}\" <- DIRECTORY NOT FOUND ");
    }
}