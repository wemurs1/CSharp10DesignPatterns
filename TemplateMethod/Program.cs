using TemplateMethod;

Console.Title = "Tmplate Method";

ExchangeMailParser exchangeMailParser = new();
Console.WriteLine(exchangeMailParser.ParseMailBody("07ef8fd3-8b5b-4c68-84f2-0d33c77d2b03"));
Console.WriteLine();

ApacheMailParser apacheMailParser = new();
Console.WriteLine(apacheMailParser.ParseMailBody("d940d791-2daf-45eb-9515-159520626a04"));
Console.WriteLine();

EudoraMailParser eudoraMailParser = new();
Console.WriteLine(eudoraMailParser.ParseMailBody("c1d23254-c3c0-4e68-958a-6c48dd8baece"));

Console.ReadKey();