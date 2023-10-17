namespace Iterator;

public class Person
{
    public string Name { get; set; }
    public string Country { get; set; }

    public Person(string name, string country)
    {
        Name = name;
        Country = country;
    }
}

/// <summary>
/// Iterator
/// </summary>
public interface IPeopleIterator
{
    Person? First();
    Person? Next();
    bool IsDone { get; }
    Person? CurrentItem { get; }
}

/// <summary>
/// Aggregate
/// </summary>
public interface IPeopleCollection
{
    IPeopleIterator CreateIterator();
}

/// <summary>
/// ConcreteAggregate
/// </summary>
public class PeopleCollection : List<Person>, IPeopleCollection
{
    public IPeopleIterator CreateIterator() => new PeopleIterator(this);
}

/// <summary>
/// ConcreteIterator
/// </summary>
public class PeopleIterator : IPeopleIterator
{
    readonly PeopleCollection _peopleCollection;
    int _current = 0;

    public PeopleIterator(PeopleCollection collection) => _peopleCollection = collection;

    public bool IsDone => _current >= _peopleCollection.Count;

    public Person CurrentItem => _peopleCollection
              .OrderBy(p => p.Name).ToList()[_current];

    public Person? First()
    {
        _current = 0;
        return IsDone
            ? null
            : _peopleCollection
                .OrderBy(p => p.Name).ToList()[_current];
    }

    public Person? Next()
    {
        _current++;
        return IsDone
            ? null
            : _peopleCollection
                .OrderBy(p => p.Name).ToList()[_current];
    }
}
