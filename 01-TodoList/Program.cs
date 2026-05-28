var todoList = new List<string>();
var exit = false;


while (!exit)
{
    Console.WriteLine(@"Hello!
What do you want to do?
[S]ee all TODOs
[A]dd a TODO
[R]emove a TODO
[E]xit");

    var userChoice = Console.ReadLine();
    switch (userChoice)
    {
        case "S":
        case "s":
            PrintTodos();
            Console.WriteLine("What do you want to do?");
            break;
        case "A":
        case "a":
            Console.WriteLine("What do you want to add to your TODO list?");
            AddTodo();
            break;
        case "R":
        case "r":

            RemoveTodoByIndex();
            break;
        case "E":
        case "e":
            Console.WriteLine("Goodbye!");
            exit = true;
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }

}

void RemoveTodoByIndex()
{
    string userInput;
    do
    {
        Console.WriteLine("Select the index of the TODO you want to remove: ");
        PrintTodos();
        userInput = Console.ReadLine()!;

    } while (!IsUserSelectedIndexValid(userInput));
    int.TryParse(userInput, out var index);

    Console.WriteLine($"TODO removed: {todoList[index - 1]}");
    todoList.RemoveAt(index - 1);

}

bool IsUserSelectedIndexValid(string input)
{
    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Selected index cannot be empty.");
        return false;
    }
    else if (!int.TryParse(input, out var index) || index > todoList.Count)
    {
        Console.WriteLine("The given index is not valid.");
        return false;
    }
    else
    {
        return true;
    }
}
void AddTodo()
{
    string userInput;

    do
    {
        Console.WriteLine("Enter the TODO description: ");
        userInput = Console.ReadLine()!;
    } while (!IsTodoValid(userInput));
    Console.WriteLine($"TODO successfully added: {userInput}");
    todoList.Add(userInput);
}

bool IsTodoValid(string input)
{
    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("The description cannot be empty. Please try again.");
        return false;
    }
    else if (todoList.Any(x => x == input))
    {
        Console.WriteLine("The description already exists in the TODO list. Please try again.");
        return false;
    }
    else
    {
        return true;
    }

}

void PrintTodos()
{
    var index = 1;
    if (todoList.Count > 0)
    {
        Console.WriteLine("Here are all your TODOs:");
        foreach (var todo in todoList)
        {
            Console.WriteLine($"{index}. {todo}");
            index++;
        }

    }
    else
    {
        Console.WriteLine("No TODOs have been added yet");
    }

}

Console.ReadKey();