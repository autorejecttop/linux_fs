# Linux File System (stripped-down)

This is a simulated stripped-down version of the Linux File System (LFS).

## Available Commands

1. `touch <filename>`
    - `touch myFile.cs`
    - `touch /home/user/Documents/myCode.php`
2. `mkdir <directoryname>`
    - `mkdir MyCourse`
    - `mkdir /home/user/Documents/MyCourse`
3. `cd <path>`
    - `cd /home/user` Moves to /home/user directory
    - `cd ..` Moves to parent directory
4. `ls [<path>]`
    - `ls MyCourse`
    - `ls`
5. `rm <path-to-file/directory>`
    - `rm /home/user/temp`
    - `rm /home/user/MyCourse/presentation.pptx`
6. `mv <source-path> <destination-path>`
    - `mv /home/user/temp/presentation.pptx /home/user/MyCourse`
7. `cp <source-path> <destination-path>`
    - `cp /home/user/temp/presentation.pptx /home/user/MyCourse`
8. `pwd`
    - `/home/user/MyCourse` Output example
9. `locate <start-path> <keyword>`
    - ```
      /home/user/temp/rectangle.png /home/user/MyCourse/directory
      /home/user/MyCourse/Algorithm/CorrectAnswer.docx
      /home/user/managing-director.txt
      ```
      
