class Program {
    private static FileSystem fs = new();

    //Menampilkan Pesan Welcome kepada user
    static void DisplayWelcomeMessage() {
        Console.WriteLine("==========================================================================================");
        Console.WriteLine("|                     Selamat Datang di Aplikasi Sistem File CLI                         |");
        Console.WriteLine("|                                                                                        |");
        Console.WriteLine("| Perintah yang Tersedia:                                                                |");
        Console.WriteLine("|  - touch <filename>    : Membuat file kosong                                           |");
        Console.WriteLine("|  - mkdir <dirname>     : Membuat direktori baru                                        |");
        Console.WriteLine("|  - cd <path>           : Berpindah direktori                                           |");
        Console.WriteLine("|  - ls [<path>]         : Menampilkan isi direktori                                     |");
        Console.WriteLine("|  - rm <path>           : Menghapus file atau direktori                                 |");
        Console.WriteLine("|  - mv <source> <destination>         : Memindahkan file atau direktori                 |");
        Console.WriteLine("|  - cp <source> <destination>         : Menyalin file atau direktori                    |");
        Console.WriteLine("|  - pwd                               : Menampilkan direktori aktif                     |");
        Console.WriteLine("|  - locate <start-path> <keyword>     : Mencari file atau direktori berdasarkan keyword |");
        Console.WriteLine("|  - help                              : Menampilkan pesan ini                           |");
        Console.WriteLine("|  - exit                              : Keluar dari aplikasi                            |");
        Console.WriteLine("|                                                                                        |");
        Console.WriteLine("| Gunakan perintah di atas untuk berinteraksi dengan sistem file.                        |");
        Console.WriteLine("==========================================================================================");
    }

    static void DisplayGoodbyeMessage() {
        Console.WriteLine("==========================================================================================");
        Console.WriteLine("|                           Sampai jumpa di lain waktu ( ^-^)/                           |");
        Console.WriteLine("==========================================================================================");
    }

    public static void Main() {
        DisplayWelcomeMessage();

        string input = "";
        while (input != "exit") {
            fs.pwd();
            input = Console.ReadLine();

            string command = input.Split(' ')[0];

            if (input == "exit")
                break;

            switch (command) {
                case "touch":
                    fs.touch(input[(command.Length + 1)..]);
                    break;
                case "mkdir":
                    fs.mkdir(input[(command.Length + 1)..]);
                    break;
                case "cd":
                    fs.cd(input[(command.Length + 1)..]);
                    break;
                case "ls":
                    fs.ls(input);
                    break;
                case "rm":
                    fs.rm(input[(command.Length + 1)..]);
                    break;
                case "mv":
                    fs.mv(input[(command.Length + 1)..]);
                    break;
                case "cp":
                    fs.cp(input[(command.Length + 1)..]);
                    break;
                case "pwd":
                    fs.pwd();
                    Console.WriteLine();
                    break;
                case "locate":
                    fs.locate(input[(command.Length + 1)..]);
                    break;
                default:
                    DisplayWelcomeMessage();
                    break;
            }
        }
        
        DisplayGoodbyeMessage();
    }
}