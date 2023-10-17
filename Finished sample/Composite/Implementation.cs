namespace Composite;

/// <summary>
/// Component
/// </summary>
public abstract class FileSystemItem
{
    public string Name { get; set; }

    public abstract long GetSize();

    protected FileSystemItem(string name) => Name = name;
}

/// <summary>
/// Leaf
/// </summary>
public class File : FileSystemItem
{
    readonly long _size;
    public File(string name, long size) : base(name) => _size = size;

    public override long GetSize() => _size;
}

/// <summary>
/// Composite
/// </summary>
public class Directory : FileSystemItem
{
    readonly List<FileSystemItem> _fileSystemItems = new();

    readonly long _size;
    public Directory(string name, long size) : base(name) => _size = size;

    public void Add(FileSystemItem itemToAdd) => _fileSystemItems.Add(itemToAdd);

    public void Remove(FileSystemItem itemToRemove) => _fileSystemItems.Remove(itemToRemove);

    public override long GetSize()
    {
        var treeSize = _size;
        foreach (FileSystemItem fileSystemItem in _fileSystemItems)
        {
            treeSize += fileSystemItem.GetSize();
        }
        return treeSize;
    }
}
