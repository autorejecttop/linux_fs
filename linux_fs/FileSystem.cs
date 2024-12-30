class FileSystem {
    private Tree Root;
    private Tree CurrentDirectory;

    public FileSystem() {
        Root = new Tree("");
        Root.Children = new List<Tree>();
        CurrentDirectory = Root;
    }

    /*  touch <filename>
        Perintah ini digunakan untuk membuat file kosong.
        Parameter yang diberikan adalah nama file.
        Jika disertakan full/relative path, maka file
        tersebut akan dibuat pada path yang ditentukan.
        Dalam satu direktori, bisa dipastikan tidak
        boleh ada nama file yang sama.
        Contoh:
        $ touch myFile.cs
        $ touch /home/user/Documents/myCode.php
    */
    public void Touch(string newFileName) {
        Tree newFile = new Tree(newFileName);

        newFile.Parent = CurrentDirectory;
        CurrentDirectory.Children.Add(newFile);
    }

    /*  mkdir <directoryname>
        Perintah ini digunakan untuk membuat direktori
        (folder) baru. Parameter yang diberikan adalah
        nama direktori (folder). Jika disertakan
        full/relative path, maka file tersebut akan
        dibuat pada path yang ditentukan. Dalam satu
        direktori, bisa dipastikan tidak boleh ada
        nama direktori yang sama.
        Contoh:
        $ mkdir MyCourse
        $ mkdir /home/user/Documents/MyCourse
    */
    public void Mkdir(string newDirectoryName) {
        Tree newDirectory = new Tree(newDirectoryName);

        newDirectory.Children = new List<Tree>();
        newDirectory.Parent = CurrentDirectory;
        CurrentDirectory.Children.Add(newDirectory);
    }

    /*  cd <path>
        Perintah ini digunakan untuk berpindah working directory menuju direktori sesuai parameter path yang diberikan.
        Contoh:
        $ cd /home/user	→ Berpindah ke direktori /home/user
        $ cd ..	→ Berpindah ke direktori parent
    */
    public void Cd(string directoryName) {
        foreach (Tree child in CurrentDirectory.Children) {
            if (child.Name != directoryName)
                continue;

            if (child.Children == null)
                throw new Exception($"{directoryName}: Not a directory");

            CurrentDirectory = child;
            return;
        }

        throw new Exception($"{directoryName}: No such file or directory");
    }

    /*  ls [<path>]
        Perintah ini digunakan untuk menampilkan isi file dan direktori di dalam suatu direktori. Jika parameter path diberikan, maka yang ditampilkan adalah isi dari direktori sesuai path. Tetapi jika parameter path tidak ada, maka yang ditampilkan adalah isi dari direktori aktif (working directory) saat ini.
        Contoh:
        $ ls MyCourse
        $ ls
    */
    public void Ls(string? directoryName = null) {
        if (directoryName == null)
            foreach (Tree child in CurrentDirectory.Children)
                Console.WriteLine(child.Name);

        foreach (Tree child in CurrentDirectory.Children) {
            if (child.Name != directoryName)
                continue;

            if (child.Children == null) {
                Console.WriteLine(child.Name);
                return;
            }

            foreach (Tree grandChild in child.Children) {
                Console.WriteLine(grandChild.Name);
            }
        }

        throw new Exception($"{directoryName}: No such file or directory");
    }

    /*  rm <path-to-file/directory>
        Perintah ini digunakan untuk menghapus file atau direktori sesuai path yang diberikan. Apabila direktori yang dihapus memiliki isi, maka otomatis menghapus seluruh isinya.
        Contoh:
        $ rm /home/user/temp
        $ rm /home/user/MyCourse/presentation.pptx
    */
    public void Rm(string fileName) {
        foreach (Tree child in CurrentDirectory.Children) {
            if (child.Name != fileName)
                continue;

            CurrentDirectory.Children.Remove(child);
            return;
        }

        throw new Exception($"{fileName}: No such file or directory");
    }

    /*  mv <source-path> <destination-path>
        Perintah ini digunakan untuk memindahkan file/direktori dari direktori asal ke direktori tujuan. Dimungkinkan juga untuk memindah direktori apabila source-path merupakan direktori.
        Contoh:
        $ mv /home/user/temp/presentation.pptx /home/user/MyCourse
    */
    public void mv() {
    }

    /*  cp <source-path> <destination-path>
        Perintah ini digunakan untuk menyalin (copy) file/direktori dari direktori asal ke direktori tujuan. Apabila yang disalin adalah direktori, maka direktori tersebut beserta seluruh isinya akan ikut tersalin.
        Contoh:
        $ cp /home/user/temp/presentation.pptx /home/user/MyCourse
    */
    public void cp() {
    }

    /*  pwd
        Perintah ini digunakan untuk menampilkan present working directory atau posisi direktori aktif saat ini.
        Contoh:
        $ pwd
        /home/user/MyCourse -> ini adalah contoh output perintah
    */
    public void pwd() {
    }

    /*  locate <start-path> <keyword>
        Perintah ini digunakan untuk mencari file atau directory dari awal posisi direktori sesuai parameter start-path yang diberikan hingga keseluruhan direktori di bawahnya. Hasil yang ditampilkan adalah semua file atau direktori yang memiliki nama sesuai keyword yang diberikan.
        Contoh:
        $ locate /home/user rect
        /home/user/temp/rectangle.png
        /home/user/MyCourse/directory
        /home/user/MyCourse/Algorithm/CorrectAnswer.docx
        /home/user/managing-director.txt
    */
    public void locate() {
    }
}