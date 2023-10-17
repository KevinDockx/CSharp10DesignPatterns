using Iterator;

Console.Title = "Iterator";

// create the collection
PeopleCollection people = new()
{
    new Person("Kevin Dockx", "Belgium"),
    new Person("Gill Cleeren", "Belgium"),
    new Person("Roland Guijt", "The Netherlands"),
    new Person("Thomas Claudius Huber", "Germany")
};

// create the iterator
IPeopleIterator peopleIterator = people.CreateIterator();

// use the iterator to run through the people
// in the collection; they should come out 
// in alphabetical order
Person person = peopleIterator.First()!;
while (!peopleIterator.IsDone)
{
    Console.WriteLine(person.Name);
    person = peopleIterator.Next()!;
}
Console.ReadKey();