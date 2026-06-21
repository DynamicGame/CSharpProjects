using _03_CookieCookbook.FileAccess;
using _03_CookieCookbook.Ingredients;


var fileFormat = FileFormat.json;
var path = fileFormat.GetFormat();
StringsRepository repository = fileFormat.GetRepository();
var userInteractor = new ConsoleUserInteractor();
var ingredientFactory = new Ingredients(userInteractor);
var recipesRepository = new RecipesRepository(repository, ingredientFactory);
var recipesUserInteractor = new RecipesUserInteractor(userInteractor,ingredientFactory,recipesRepository);

var app = new CookieCookBookApp(recipesUserInteractor, recipesRepository,userInteractor);
app.Run(path);





Console.ReadKey();
