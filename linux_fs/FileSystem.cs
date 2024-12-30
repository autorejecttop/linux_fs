class FileSystem {
    private TreeSystem root;
    private TreeSystem CWD;

    public FileSystem() {
        this.root = new TreeSystem("~", Type.Directory);
        this.CWD = root;
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
    public void touch(String arg) {
        if (arg.ElementAt(0).Equals('/')) {
            String fileName = "";
            TreeSystem? parent = null;
            String[] paths = arg.Split('/', StringSplitOptions.RemoveEmptyEntries);

            if (paths.Length <= 1) {
                ERRMSG.INV_COMMAND(arg);
            } else {
                fileName = paths.Last();
                paths = paths.Take(paths.Length - 1).ToArray();
                parent = root.GoToTree(root, paths);
                if (parent != null) {
                    helper(fileName, Type.File, parent);
                }
            }
        } else {
            helper(arg, Type.File, CWD);
        }
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
    public void mkdir(String arg) {
        if (arg.ElementAt(0).Equals('/')) {
            String dirName = "";
            TreeSystem? parent = null;
            String[] paths = arg.Split('/', StringSplitOptions.RemoveEmptyEntries);

            if (paths.Length <= 1) {
                ERRMSG.INV_COMMAND(arg);
            } else {
                dirName = paths.Last();
                paths = paths.Take(paths.Length - 1).ToArray();
                parent = root.GoToTree(root, paths);
                if (parent != null) {
                    helper(dirName, Type.Directory, parent);
                }
            }
        } else {
            helper(arg, Type.Directory, CWD);
        }
    }

    /*  cd <path>
        Perintah ini digunakan untuk berpindah working 
        directory menuju direktori sesuai parameter path yang diberikan.
        Contoh:
        $ cd /home/user	→ Berpindah ke direktori /home/user
        $ cd ..	→ Berpindah ke direktori parent
    */
    public void cd(String arg) {
        if (arg.Equals("..") && !CWD.Equals(root) && CWD.parent != null) {
            CWD = CWD.parent;
        } else if (arg.Equals("~")) {
            CWD = root;
        } else if (arg.ElementAt(0).Equals('/')) {
            String[] paths = arg.Split('/', StringSplitOptions.RemoveEmptyEntries);
            if (paths.Length > 0) {
                TreeSystem? tree = root.GoToTree(root, paths);
                if (tree != null) CWD = tree;
            } else {
                ERRMSG.INV_COMMAND(arg);
            }
        } else {
            TreeSystem? tree = CWD.GetTree(arg, Type.Directory);
            if (tree != null) CWD = tree;
        }
    }

    /*  ls [<path>]
        Perintah ini digunakan untuk menampilkan 
        isi file dan direktori di dalam suatu direktori. 
        Jika parameter path diberikan, maka yang 
        ditampilkan adalah isi dari direktori sesuai 
        path. Tetapi jika parameter path tidak ada, 
        maka yang ditampilkan adalah isi dari direktori 
        aktif (working directory) saat ini.
        Contoh:
        $ ls MyCourse
        $ ls
    */
    public void ls(String arg) {
        String[] paths = arg.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (arg.Equals("ls")) {
            ls(CWD);
        } else if (paths.Length == 2) {
            if (paths[1].ElementAt(0).Equals('/')) {
                TreeSystem? DIR = root.GoToTree(root, paths);
                if (DIR != null) ls(DIR);
            } else {
                TreeSystem? DIR = CWD.GetTree(paths[1], Type.Directory);
                if (DIR != null) ls(DIR);
            }
        }

        static void ls(TreeSystem DIR) {
            if (DIR.children.Count > 0) {
                printDash();
                Console.WriteLine("TYPE\t\tNAME");
                printDash();
                foreach (TreeSystem tree in DIR.children) {
                    Console.Write($"{tree.type}");
                    if (tree.type.Equals(Type.File))
                        Console.Write("\t\t");
                    else
                        Console.Write("\t");
                    Console.Write($"{tree.name}\n");
                }
                printDash();
            }
        }

        static void printDash() {
            for (int i = 0; i < 10; i++)
                Console.Write("─────");
            Console.WriteLine();
        }
    }

    /*  rm <path-to-file/directory>
        Perintah ini digunakan untuk menghapus 
        file atau direktori sesuai path yang 
        diberikan. Apabila direktori yang 
        dihapus memiliki isi, maka otomatis 
        menghapus seluruh isinya.
        Contoh:
        $ rm /home/user/temp
        $ rm /home/user/MyCourse/presentation.pptx
    */
    public void rm(String arg) {
        if (arg.ElementAt(0).Equals('/')) {
            String[] paths = arg.Split('/', StringSplitOptions.RemoveEmptyEntries);
            TreeSystem? DIR = root.GoToTree(root, paths.Take(paths.Length - 1).ToArray());
            if (DIR != null) rm(DIR, paths.Last());
        } else {
            rm(CWD, arg);
        }

        static void rm(TreeSystem DIR, String arg) {
            TreeSystem? removeFile = DIR.GetTree(arg, Type.File, false);
            TreeSystem? removeDir = DIR.GetTree(arg, Type.Directory, false);
            if (removeFile != null) {
                DIR.children.Remove(removeFile);
            } else if (removeDir != null) {
                DIR.children.Remove(removeDir);
            } else {
                ERRMSG.FILE_DIR_NOT_FOUND(arg);
            }
        }
    }

    /*  mv <source-path> <destination-path>
        Perintah ini digunakan untuk memindahkan 
        file/direktori dari direktori asal ke direktori 
        tujuan. Dimungkinkan juga untuk memindah 
        direktori apabila source-path merupakan direktori.
        Contoh:
        $ mv /home/user/temp/presentation.pptx /home/user/MyCourse
    */
    public void mv(String arg, bool delete = true) {
        String[] paths = arg.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        TreeSystem? file_src = null;
        TreeSystem? dir_src = null;
        TreeSystem? dst = null;

        if (paths[0].ElementAt(0).Equals('/')) {
            String[] src_paths = paths[0].Split('/', StringSplitOptions.RemoveEmptyEntries);
            file_src = root.GoToTree(root, src_paths, false);
            dir_src = root.GoToTree(root, src_paths, false);
        } else {
            file_src = CWD.GetTree(paths[0], Type.File, false);
            dir_src = CWD.GetTree(paths[0], Type.Directory, false);
        }

        if (paths[1].ElementAt(0).Equals('/')) {
            String[] dst_paths = paths[1].Split('/', StringSplitOptions.RemoveEmptyEntries);
            dst = root.GoToTree(root, dst_paths, false);
        } else {
            dst = CWD.GetTree(paths[1], Type.Directory, false);
        }

        if ((file_src != null || dir_src != null) && dst != null) {
            TreeSystem src = file_src ?? dir_src;

            if (delete) rm(paths[0]);
            src.parent = dst;
            dst.children.Add(src);
        } else if (file_src == null && dir_src == null) {
            ERRMSG.FILE_DIR_NOT_FOUND(paths[0]);
        } else if (dst == null) {
            ERRMSG.DIR_NOT_FOUND(paths[1]);
        }
    }

    /*  cp <source-path> <destination-path>
        Perintah ini digunakan untuk menyalin (copy) file/direktori 
        dari direktori asal ke direktori tujuan. Apabila yang 
        disalin adalah direktori, maka direktori tersebut beserta 
        seluruh isinya akan ikut tersalin.
        Contoh:
        $ cp /home/user/temp/presentation.pptx /home/user/MyCourse
    */
    public void cp(String arg) {
        mv(arg, false);
    }

    /*  pwd
        Perintah ini digunakan untuk menampilkan 
        present working directory atau posisi direktori aktif saat ini.
        Contoh:
        $ pwd
        /home/user/MyCourse -> ini adalah contoh output perintah
    */
    public void pwd() {
        Console.WriteLine($"{cwdPath()}");
    }

    /*  locate <start-path> <keyword>
        Perintah ini digunakan untuk mencari file atau 
        directory dari awal posisi direktori sesuai parameter 
        start-path yang diberikan hingga keseluruhan direktori 
        di bawahnya. Hasil yang ditampilkan adalah semua file 
        atau direktori yang memiliki nama sesuai keyword yang diberikan.
        Contoh:
        $ locate /home/user rect
        /home/user/temp/rectangle.png
        /home/user/MyCourse/directory
        /home/user/MyCourse/Algorithm/CorrectAnswer.docx
        /home/user/managing-director.txt
    */
    public void locate() { }

    // ========= CUSTOM METHOD ========= //
    public String cwdPath() {
        String result = root.name;
        TreeSystem searchTree = CWD;

        while (!searchTree.Equals(root) && searchTree.parent != null) {
            result = $"{result[0]}/{searchTree.name}{result.Remove(0, 1)}";
            searchTree = searchTree.parent;
        }

        return result;
    }

    void helper(String name, Type type, TreeSystem parent) {
        if (parent.IsExist(name, type)) {
            if (type.Equals(Type.File))
                ERRMSG.FILE_ALR_EXIST(name);
            else
                ERRMSG.DIR_ALR_EXIST(name);
        } else {
            TreeSystem newTree = new TreeSystem(name, type, parent);
            parent.children.Add(newTree);
        }
    }
}