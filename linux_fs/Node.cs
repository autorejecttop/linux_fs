namespace linux_fs;

public class Node
{
    public string? Data;
    public Node? Parent;
    public List<Node>? Children;
    
    public Node(string? data = null)
    {
        Data = data;
    }
}