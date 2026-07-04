using _09_CustomLinkedList;


var myList = new CustomLinkedList<int>() { 1,2,3,3,4,5};

foreach(var item in myList)
{
    Console.WriteLine(item);
}
Console.WriteLine(myList.Count);
Console.WriteLine(myList.Contains(3));
Console.WriteLine(myList.Remove(3));
Console.WriteLine("count after remove " + myList.Count);
myList.AddToFront(10);
Console.WriteLine($"count after add to front {myList.Count}");
myList.Add(19);
myList.AddToEnd(20);

foreach (var item in myList)
{
    Console.WriteLine(item);
}

var array = new int[2];

myList.CopyTo(array, 2);


Console.ReadKey();




