class CSLMSG {
    public static void CMD_NOT_FOUND(String arg) {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($" ERR: \"{arg}\" <- COMMAND NOT FOUND ");
        Console.ResetColor();
    }

    public static void CMD_TMA(String arg) {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($" ERR: \"{arg}\" <- TOO MUCH ARGUMENT ");
        Console.ResetColor();
    }

    public static void CMD_INCOMPLETE(String arg) {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($" ERR: \"{arg}\" <- COMMAND INCOMPLETE ");
        Console.ResetColor();
    }

    public static void PATH_INCOMPLETE(String arg) {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($" ERR: \"{arg}\" <- PATH INCOMPLETE ");
        Console.ResetColor();
    }

    public static void RM_ROOT() {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($" ERR: DELETING ROOT IS ILLEGAL!! ");
        Console.ResetColor();
    }

    public static void NAME_ROOT() {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($" ERR: NAMING FILE/DIRECTORY SAME AS ROOT IS ILLEGAL!! ");
        Console.ResetColor();
    }

    public static void ALPH_NUM(String arg) {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($" ERR: \"{arg}\" <- ONLY ALPHANUMERIC IS ALLOWED ");
        Console.ResetColor();
    }

    public static void FILE_ALR_EXIST(String arg) {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($" ERR: \"{arg}\" <- FILE ALREADY EXISTED ");
        Console.ResetColor();
    }

    public static void DIR_ALR_EXIST(String arg) {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.Black;
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

    public static void FILE_DIR_NOT_FOUND(String arg) {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($" ERR: \"{arg}\" <- FILE/DIRECTORY NOT FOUND ");
        Console.ResetColor();
    }
}