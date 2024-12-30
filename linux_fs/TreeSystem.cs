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

    public TreeSystem? GetTree(String name, Type type, bool verbose = true) {
        TreeSystem? result = null;

        foreach (TreeSystem tree in children) {
            if (tree.name.Equals(name) && tree.type.Equals(type)) {
                result = tree;
                break;
            }
        }
        if (result == null && verbose) {
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

    public TreeSystem? GoToTree(TreeSystem root, String[] paths, bool verbose = true) {
        String CSD = "";
        TreeSystem? result = root;

        foreach (String path in paths) {
            CSD += $"/{path}";
            result = result.GetTree(path, Type.Directory, false);
            if (result == null) {
                if (verbose) ERRMSG.DIR_NOT_FOUND(CSD);
                break;
            }
        }

        return result;
    }

    public String fullPath(TreeSystem root) {
        String result = root.name;
        TreeSystem searchTree = this;

        while (!searchTree.Equals(root) && searchTree.parent != null) {
            result = $"{result[0]}/{searchTree.name}{result.Remove(0, 1)}";
            searchTree = searchTree.parent;
        }

        return result;
    }
}

public enum Type { File, Directory }