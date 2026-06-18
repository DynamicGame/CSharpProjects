using _03_CookieCookbook.FileAccess;


var fileFormat = FileFormat.json;
var path = fileFormat == FileFormat.txt ? "recipes.txt" : "recipes.json";

//var app = new CookieCookBookApp(path, consoleInteractor, );
//app.Run();



Console.ReadKey();
