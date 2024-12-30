FileSystem fs = new();

fs.Mkdir("home");
fs.Cd("home");
fs.Mkdir("user");
fs.Cd("user");
fs.Mkdir("mycourse");
fs.Mkdir("MyCourse");
fs.Cd("MyCourse");
fs.Touch("presentation.pptx");
fs.Mv("/home/user/MyCourse/presentation.pptx", "/home/user/MyCourse");

// fs.Ls();
// fs.Pwd();
//
// fs.Cd("..");
//
// fs.Mkdir("lol");
// fs.Cd("lol");
// fs.Touch("testing.txt");
//
// fs.Ls();
// fs.Pwd();
//
// fs.Cd("..");
// fs.Ls("lol");
// fs.Pwd();