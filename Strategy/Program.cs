using Strategy;

Console.Title = "Strategy Pattern";

var order = new Order("Marvin Software", 5, "Visual Studio License");
order.ExportService = new CSVExportService();
order.Export();

order.ExportService = new JsonExportService();
order.Export();

Console.ReadKey();