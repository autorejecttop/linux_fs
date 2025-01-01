using System.Text.RegularExpressions;

class Program {
    private static FileSystem fs = new();

    //Menampilkan Pesan Welcome kepada user
    static void DisplayWelcomeMessage() {
        Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────────────┐");
        Console.WriteLine("│                       Selamat Datang di Aplikasi Sistem File CLI                        │");
        Console.WriteLine("│                                                                                         │");
        Console.WriteLine("│ Perintah yang Tersedia:                                                                 │");
        Console.WriteLine("│  - touch <filename>                  : Membuat file kosong                              │");
        Console.WriteLine("│  - mkdir <dirname>                   : Membuat direktori baru                           │");
        Console.WriteLine("│  - cd <path>                         : Berpindah direktori                              │");
        Console.WriteLine("│  - ls [<path>]                       : Menampilkan isi direktori                        │");
        Console.WriteLine("│  - rm <path>                         : Menghapus file atau direktori                    │");
        Console.WriteLine("│  - mv <source> <destination>         : Memindahkan file atau direktori                  │");
        Console.WriteLine("│  - cp <source> <destination>         : Menyalin file atau direktori                     │");
        Console.WriteLine("│  - pwd                               : Menampilkan direktori aktif                      │");
        Console.WriteLine("│  - locate <start-path> <keyword>     : Mencari file atau direktori berdasarkan keyword  │");
        Console.WriteLine("│  - help                              : Menampilkan pesan ini                            │");
        Console.WriteLine("│  - exit                              : Keluar dari aplikasi                             │");
        Console.WriteLine("│                                                                                         │");
        Console.WriteLine("│ Gunakan perintah di atas untuk berinteraksi dengan sistem file.                         │");
        Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────────────┘");
    }

    static void DisplayGoodbyeMessage() {
        Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────────────┐");
        Console.WriteLine("│                           Sampai jumpa di lain waktu ( ^-^)//                           │");
        Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────────────┘");
    }

    public static void Main() {
        DisplayWelcomeMessage();

        string input;
        do {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"ras@m4tree:{fs.pwd()}$ ");
            Console.ResetColor();

            input = Console.ReadLine().Trim();
            if (!input.Equals("") && Regex.IsMatch(input.Replace("/", string.Empty), @"^[a-zA-Z0-9.~ ]+$"))
                Call(input);
            else if (input.Equals("")) continue;
            else CSLMSG.ALPH_NUM(input);
        } while (input != "exit");

        DisplayGoodbyeMessage();
    }

    public static void Call(String cmd) {
        List<dynamic> result;
        switch (cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]) {
            case "touch":
                result = validate(cmd, 2);
                if (result[0]) fs.touch(result[1]);
                break;
            case "mkdir":
                result = validate(cmd, 2);
                if (result[0]) fs.mkdir(result[1]);
                break;
            case "cd":
                result = validate(cmd, 2);
                if (result[0]) fs.cd(result[1]);
                break;
            case "ls":
                fs.ls(cmd);
                break;
            case "rm":
                result = validate(cmd, 2);
                if (result[0]) fs.rm(result[1]);
                break;
            case "mv":
                result = validate(cmd, 3);
                if (result[0]) fs.mv(result[1]);
                break;
            case "cp":
                result = validate(cmd, 3);
                if (result[0]) fs.cp(result[1]);
                break;
            case "pwd":
                fs.pwd();
                break;
            case "locate":
                result = validate(cmd, 3);
                if (result[0]) fs.locate(result[1]);
                break;
            default:
                CSLMSG.CMD_NOT_FOUND(cmd);
                break;
        }

        static List<dynamic> validate(String cmd, int total) {
            bool result = false;
            string finalArg = "";
            String[] args = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (args.Length < total) {
                CSLMSG.CMD_INCOMPLETE(cmd);
            } else if (args.Length > total) {
                CSLMSG.CMD_TMA(cmd);
            } else if (args[1].ElementAt(0).Equals('/')) {
                String[] paths = args[1].Split('/', StringSplitOptions.RemoveEmptyEntries);
                if (paths.Length < 1) CSLMSG.PATH_INCOMPLETE(args[1]);
                else result = true;

                if (total == 3) {
                    if (args[2].ElementAt(0).Equals('/')) {
                        String[] paths_2 = args[2].Split('/', StringSplitOptions.RemoveEmptyEntries);
                        if (paths_2.Length < 1) CSLMSG.PATH_INCOMPLETE(args[2]);
                        else result = true;
                    } else {
                        result = true;
                    }
                }
            } else {
                result = true;
            }

            if (result) {
                if (total == 2) {
                    finalArg = args[1];
                } else if (total == 3) {
                    finalArg = $"{args[1]} {args[2]}";
                }
            }

            return [result, finalArg];
        }
    }
}