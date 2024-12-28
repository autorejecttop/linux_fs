// Komentar
public class TreeSystem {
    public String data;
    public Type type;
    public List<TreeSystem> children;

    public TreeSystem(String data, Type type) {
        this.data = data;
        this.type = type;
        this.children = [];
    }
}

public enum Type { File, Folder }