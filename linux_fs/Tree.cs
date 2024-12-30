public class Tree {
    public string Name;
    public Tree Parent;
    public List<Tree>? Children;

    public Tree(string name) {
        Name = name;
    }
}