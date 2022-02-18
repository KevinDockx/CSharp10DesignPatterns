namespace Iterator
{
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
        Person First();
        Person Next();
        bool IsDone { get; }
        Person CurrentItem { get; }
    }

    /// <summary>
    /// ConcreteIterator
    /// </summary>
    public class PeopleIterator : IPeopleIterator
    {
        private PeopleCollection _peopleCollection;
        private int _current = 0; 
     
        public PeopleIterator(PeopleCollection collection)
        {
            _peopleCollection = collection;
        } 

        public Person First()
        {
            _current = 0;
            return _peopleCollection
                .OrderBy(p => p.Name).ToList()[_current];
        }

        public Person Next()
        {
            _current++;
            if (!IsDone)
            {                
                return _peopleCollection
                    .OrderBy(p => p.Name).ToList()[_current];   
            }
            else
            {
                return null;
            }
        }

        public bool IsDone
        {
            get { return _current >= _peopleCollection.Count; }
        }

        public Person CurrentItem
        {
            get { return _peopleCollection
                    .OrderBy(p => p.Name).ToList()[_current]; }
        }   
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
        public IPeopleIterator CreateIterator()
        {
            return new PeopleIterator(this);
        } 
    }
}
