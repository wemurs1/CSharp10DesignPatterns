using Builder;

Console.Title = "Builder";

var garage = new Garage();

var minBuilder = new MiniBuilder();
var bmwBuilder = new BMWBuilder();

garage.Construct(minBuilder);
Console.WriteLine(minBuilder.Car.ToString());
// or:
garage.Show();

garage.Construct(bmwBuilder);
Console.WriteLine(bmwBuilder.Car.ToString());
// or:
garage.Show();

Console.ReadKey();