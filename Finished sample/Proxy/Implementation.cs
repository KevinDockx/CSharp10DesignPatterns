namespace Proxy;

/// <summary>
/// Subject
/// </summary>
public interface IDocument
{
    void DisplayDocument();
}

/// <summary>
/// RealSubject
/// </summary>
public class Document : IDocument
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int AuthorId { get; set; }
    public DateTimeOffset LastAccessed { get; set; }
    readonly string _fileName;

    public Document(string fileName)
    {
        _fileName = fileName;
        LoadDocument(fileName);
    }

    void LoadDocument(string fileName)
    {
        Console.WriteLine("Executing expensive action: loading a file from disk");
        // fake loading...
        Thread.Sleep(1000);

        Title = "An expensive document";
        Content = "Lots and lots of content";
        AuthorId = 1;
        LastAccessed = DateTimeOffset.UtcNow;
    }

    public void DisplayDocument() => Console.WriteLine($"Title: {Title}, Content: {Content}");
}

/// <summary>
/// Proxy
/// </summary>
public class DocumentProxy : IDocument
{
    // avoid creating the document until we need it 
    readonly Lazy<Document> _document;
    readonly string _fileName;

    public DocumentProxy(string fileName)
    {
        _fileName = fileName;
        _document = new Lazy<Document>(() => new Document(_fileName));
    }

    public void DisplayDocument() => _document.Value.DisplayDocument();
}

/// <summary>
/// Proxy
/// </summary>
public class ProtectedDocumentProxy : IDocument
{
    readonly string _fileName;
    readonly string _userRole;
    readonly DocumentProxy _documentProxy;

    public ProtectedDocumentProxy(string fileName,
        string userRole)
    {
        _fileName = fileName;
        _userRole = userRole;
        _documentProxy = new DocumentProxy(_fileName);
    }

    public void DisplayDocument()
    {
        Console.WriteLine("Entering DisplayDocument " +
            $"in {nameof(ProtectedDocumentProxy)}.");

        if (_userRole != "Viewer")
        {
            throw new UnauthorizedAccessException();
        }

        _documentProxy.DisplayDocument();

        Console.WriteLine("Exiting DisplayDocument " +
            $"in {nameof(ProtectedDocumentProxy)}.");
    }
}
