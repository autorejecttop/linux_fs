namespace linux_fs;

public class Node
{
    public string? Name;
    public Node? Parent;
    public List<Node>? Children;
    
    public Node(string? name = null)
    {
        Name = name;
    }
}