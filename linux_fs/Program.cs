class Program {

    static FileSystem fs = new FileSystem();
    public static void Main() {

        //Menampilkan Pesan Welcome kepada user
        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine(" Selamat Datang di Aplikasi Sistem File CLI");
            Console.WriteLine("=========================================");
            Console.WriteLine("");
            Console.WriteLine("Perintah yang Tersedia:");
            Console.WriteLine("  - touch <filename>    : Membuat file kosong");
            Console.WriteLine("  - mkdir <dirname>     : Membuat direktori baru");
            Console.WriteLine("  - cd <path>           : Berpindah direktori");
            Console.WriteLine("  - ls [<path>]         : Menampilkan isi direktori");
            Console.WriteLine("  - rm <path>           : Menghapus file atau direktori");
            Console.WriteLine("  - mv <source> <destination>         : Memindahkan file atau direktori");
            Console.WriteLine("  - cp <source> <destination>         : Menyalin file atau direktori");
            Console.WriteLine("  - pwd                               : Menampilkan direktori aktif");
            Console.WriteLine("  - locate <start-path> <keyword>     : Mencari file atau direktori berdasarkan keyword");
            Console.WriteLine("  - exit                              : Keluar dari aplikasi");
            Console.WriteLine("");
            Console.WriteLine("Gunakan perintah di atas untuk berinteraksi dengan sistem file.");
            Console.WriteLine("=========================================");

        }
        
        Console.Readline(DisplayWelcomeMessage);
        
        // Dictionary untuk memetakan perintah string ke fungsi yang sesuai dari file system
            Dictionary<string, Action<string[]>> commands = new Dictionary<string, Action<string[]>>
            {
                { "touch", TouchCommand },
                { "mkdir", MkdirCommand },
                { "cd", CdCommand },
                { "ls", LsCommand },
                { "rm", RmCommand },
                { "mv", MvCommand },
                { "cp", CpCommand },
                { "pwd", PwdCommand },
                 { "locate", LocateCommand },
                { "exit", ExitCommand }
            };
        
            

    }
}