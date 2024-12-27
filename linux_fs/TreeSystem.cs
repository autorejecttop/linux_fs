// Komentar
public class TreeSystem {
    public String data;
    public NodeType type;
    public LinkedListNode<TreeSystem>? children;

    public TreeSystem(String data, NodeType type) {
        this.data = data;
        this.type = type;
    }
}

public enum NodeType { File, Folder }