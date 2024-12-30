class Program {

    static FileSystem fs = new FileSystem();
    public static void Main() {

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