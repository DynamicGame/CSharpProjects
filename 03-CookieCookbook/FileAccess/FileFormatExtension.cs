namespace _03_CookieCookbook.FileAccess;

public static class FileFormatExtension
    {
    public static string GetFormat(this FileFormat format) 
    {
        return format == FileFormat.txt ? "recipes.txt" : "recipes.json";
    }

    public static StringsRepository GetRepository(this FileFormat format)
    {
        return format == FileFormat.txt ? new TextualRepository() : new JsonRepository();
    }
}