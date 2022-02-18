using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    /// <summary>
    /// Component
    /// </summary>
    public abstract class FileSystemItem
    {
        public string Name { get; set; }
        
        public abstract long GetSize();

        public FileSystemItem(string name)
        {
            Name = name;
        }
    }


    /// <summary>
    /// Leaf
    /// </summary>
    public class File : FileSystemItem
    {
        private long _size; 
        public File(string name, long size) : base(name)
        {
            _size = size;
        }

        public override long GetSize()
        {
            return _size;
        }         
    }

    /// <summary>
    /// Composite
    /// </summary>
    public class Directory : FileSystemItem
    {
        private long _size;
        private List<FileSystemItem> _fileSystemItems { get; set; } = new List<FileSystemItem>();
        
        public Directory(string name, long size) : base(name)
        {
            _size = size;
        }

        public void Add(FileSystemItem itemToAdd)
        {
            _fileSystemItems.Add(itemToAdd);
        }

        public void Remove(FileSystemItem itemToRemove)
        {
            _fileSystemItems.Remove(itemToRemove);
        }

        public override long GetSize()
        {
            var treeSize = _size;
            foreach (var fileSystemItem in _fileSystemItems)
            {
                treeSize += fileSystemItem.GetSize();
            }
            return treeSize;
        }
    }


}
