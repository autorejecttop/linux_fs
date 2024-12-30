public class TreeSystem {
    public String name;
    public Type type;
    public TreeSystem? parent;
    public List<TreeSystem> children;

    public TreeSystem(String name, Type type, TreeSystem? parent = null) {
        this.name = name;
        this.type = type;
        this.parent = parent;
        this.children = [];
    }

    public TreeSystem? GetTree(String data, Type type) {
        TreeSystem? result = null;
        foreach (TreeSystem tree in children) {
            if (tree.name.Equals(data) && tree.type.Equals(type)) {
                result = tree;
            }
        }
        return result;
    }
}

public enum Type { File, Folder }