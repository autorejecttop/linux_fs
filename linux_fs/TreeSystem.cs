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

    public TreeSystem? GetTree(String name, Type type) {
        TreeSystem? result = null;

        foreach (TreeSystem tree in children) {
            if (tree.name.Equals(name) && tree.type.Equals(type)) {
                result = tree;
                break;
            }
        }
        if (result == null) {
            if (type.Equals(Type.File))
                ERRMSG.FILE_NOT_FOUND(name);
            else
                ERRMSG.DIR_NOT_FOUND(name);
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

    public TreeSystem? GoToTree(TreeSystem root, String[] paths) {
        String CSD = "";
        TreeSystem? result = root;

        foreach (String path in paths) {
            CSD += $"/{path}";
            result = result.GetTree(path, Type.Directory);
            if (result == null) {
                ERRMSG.DIR_NOT_FOUND(CSD);
                break;
            }
        }

        return result;
    }
}

public enum Type { File, Directory }