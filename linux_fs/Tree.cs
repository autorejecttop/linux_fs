public class Tree {
    public String Name;
    public Tree Parent;
    public List<Tree>? Children;

    public Tree(String name) {
        Name = name;
    }
}