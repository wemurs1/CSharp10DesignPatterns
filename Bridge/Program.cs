using Bridge;

Console.Title = "Bridge";

var noCoupon = new NoCoupon();
var oneEuroCoupon = new OnEuroCoupon();
var twoEuroCoupon = new TwoEuroCoupon();

var meatBasedMenu = new MeatMenu(noCoupon);
Console.WriteLine($"Meat based menu, no coupon: {meatBasedMenu.CalculatePrice()} euro.");

meatBasedMenu = new MeatMenu(oneEuroCoupon);
Console.WriteLine($"Meat based menu, one euro coupon: {meatBasedMenu.CalculatePrice()} euro.");

var vegetarianBasedMenu = new VegetarianMenu(noCoupon);
Console.WriteLine($"Vegetarian based menu, no coupon: {vegetarianBasedMenu.CalculatePrice()} euro.");

vegetarianBasedMenu = new VegetarianMenu(oneEuroCoupon);
Console.WriteLine($"Vegetarian based menu, one euro coupon: {vegetarianBasedMenu.CalculatePrice()} euro.");

Console.ReadKey();