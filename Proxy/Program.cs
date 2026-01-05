Console.Title = "Proxy";

// without proxy
Console.WriteLine("Constructing document");
var myDocument = new Proxy.Document("MyDocument.pdf");
Console.WriteLine("Document constructed.");
myDocument.DisplayDocument();

Console.WriteLine();

// with proxy
Console.WriteLine("Constructing document proxy");
var myDocumentProxy = new Proxy.DocumentProxy("MyDocument.pdf");
Console.WriteLine("Document proxy constructed");
myDocumentProxy.DisplayDocument();

Console.ReadKey();