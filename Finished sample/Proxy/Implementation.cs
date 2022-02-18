using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    /// <summary>
    /// RealSubject
    /// </summary>
    public class Document : IDocument
    {
        public string? Title { get; private set; }
        public string? Content { get; private set; }
        public int AuthorId { get; private set; }
        public DateTimeOffset LastAccessed { get; private set; }
        private string _fileName; 
         
        public Document(string fileName)
        {
            _fileName = fileName;
            LoadDocument(fileName);
        }

        private void LoadDocument(string fileName)
        {
            Console.WriteLine("Executing expensive action: loading a file from disk");
            // fake loading...
            Thread.Sleep(1000);

            Title = "An expensive document";
            Content = "Lots and lots of content";
            AuthorId = 1;
            LastAccessed = DateTimeOffset.UtcNow;
        }

        public void DisplayDocument()
        {
            Console.WriteLine($"Title: {Title}, Content: {Content}");
        }
    }

    /// <summary>
    /// Subject
    /// </summary>
    public interface IDocument
    {
        void DisplayDocument();
    }

    /// <summary>
    /// Proxy
    /// </summary>
    public class DocumentProxy : IDocument
    {
        // avoid creating the document until we need it 
        private Lazy<Document> _document;
        private string _fileName;

        public DocumentProxy(string fileName)
        {
            _fileName = fileName;
            _document = new Lazy<Document>(() => new Document(_fileName));
        }

        public void DisplayDocument()
        {
            _document.Value.DisplayDocument();       
        }
    }

    public class ProtectedDocumentProxy : IDocument
    {
        private string _fileName;
        private string _userRole;
        private DocumentProxy _documentProxy;

        public ProtectedDocumentProxy(string fileName, 
            string userRole)
        {
            _fileName = fileName;
            _userRole = userRole;
            _documentProxy = new DocumentProxy(_fileName);
        }
        
        public void DisplayDocument()
        {
            Console.WriteLine($"Entering DisplayDocument in {nameof(ProtectedDocumentProxy)}.");

            if (_userRole != "Viewer")
            {
                throw new UnauthorizedAccessException();
            }

            _documentProxy.DisplayDocument();

            Console.WriteLine($"Exiting DisplayDocument in {nameof(ProtectedDocumentProxy)}.");
        }
    }
}
