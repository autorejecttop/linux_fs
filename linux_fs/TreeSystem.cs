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

    private TreeSystem? GetTree(String name, Type type) {
        TreeSystem? result = null;
        foreach (TreeSystem tree in children) {
            if (tree.name.Equals(name) && tree.type.Equals(type)) {
                result = tree;
            }
        }
        return result;
    }

    public bool IsExist(String name, Type type) {
        bool result = false;
        foreach (TreeSystem tree in children) {
            if (tree.name.Equals(name) && tree.type.Equals(type)) {
                result = true;
                break;
            }
        }
        return result;
    }

    public TreeSystem? GoToTree(TreeSystem root, String arg) {
        String CSD = "";
        TreeSystem? result = root;
        String[] paths = arg.Split('/', StringSplitOptions.RemoveEmptyEntries);

        if (paths.Length <= 1) {
            ERRMSG.INV_COMMAND(arg);
        } else {
            foreach (String path in paths) {
                CSD += $"/{path}";
                result = result.GetTree(path, Type.Folder);
                if (result == null) {
                    ERRMSG.DIR_NOT_FOUND(CSD);
                    break;
                }
            }
        }

        return result;
    }
}

public enum Type { File, Folder }