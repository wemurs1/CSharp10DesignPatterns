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
    public string? Title { get; private set; }
    public string? Content { get; private set; }
    public int AuthorId { get; private set; }
    public DateTimeOffset LastAccessed { get; set; }
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
        Content = "lots and lots of content";
        AuthorId = 1;
        LastAccessed = DateTimeOffset.UtcNow;
    }

    public void DisplayDocument()
    {
        Console.WriteLine($"Title: {Title}, Content: {Content}");
    }
}

/// <summary>
/// Proxy
/// </summary>
public class DocumentProxy : IDocument
{
    private Lazy<Document> _document;
    private readonly string _fileName;

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