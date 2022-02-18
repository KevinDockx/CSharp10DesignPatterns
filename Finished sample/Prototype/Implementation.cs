using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Prototype
{
    /// <summary>
    /// Prototype abstract class
    /// </summary>
    public abstract class Person
    {
        public abstract string Name { get; set; }

        public abstract Person Clone(bool deepClone);
      
    }

    /// <summary>
    /// ConcretePrototype1
    /// </summary>
    public class Employee : Person
    {
        public Manager Manager { get; set; }
        public override string Name { get; set; }
         
        public Employee(string name, Manager manager)
        {
            Name = name;
            Manager = manager;
        }

        public override Person Clone(bool deepClone = false)
        {
            if (deepClone)
            {
                var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                var objectAsJson = JsonConvert.SerializeObject(this, typeof(Employee), settings);
                return JsonConvert.DeserializeObject<Person>(objectAsJson, settings);
            }


            return (Person)MemberwiseClone();
        }
    }

    /// <summary>
    /// ConcretePrototype2
    /// </summary>
    public class Manager : Person
    {
        public override string Name { get; set; }
 
        public Manager(string name)
        {
            Name = name;
        }

        public override Person Clone(bool deepClone = false)
        {
            if (deepClone)
            {
                var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                var objectAsJson = JsonConvert.SerializeObject(this, typeof(Manager), settings);
                return JsonConvert.DeserializeObject<Person>(objectAsJson, settings);
            }

            return (Person)MemberwiseClone();
        }
    }
}
