class ERRMSG {
    public static void INV_COMMAND(String arg) {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($" ERR: \"{arg}\" <- INVALID COMMAND ");
        Console.ResetColor();
    }

    public static void FILE_ALR_EXIST(String arg) {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($" ERR: \"{arg}\" <- FILE ALREADY EXISTED ");
        Console.ResetColor();
    }

    public static void DIR_ALR_EXIST(String arg) {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($" ERR: \"{arg}\" <- DIRECTORY ALREADY EXISTED ");
        Console.ResetColor();
    }

    public static void FILE_NOT_FOUND(String arg) {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($" ERR: \"{arg}\" <- FILE NOT FOUND ");
        Console.ResetColor();
    }

    public static void DIR_NOT_FOUND(String arg) {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($" ERR: \"{arg}\" <- DIRECTORY NOT FOUND ");
        Console.ResetColor();
    }
}