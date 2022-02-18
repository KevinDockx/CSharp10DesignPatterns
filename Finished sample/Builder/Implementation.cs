using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{


    /// <summary>
    /// Director
    /// </summary>
    public class Garage
    {
        private CarBuilder? _builder;
         
        public Garage()
        {
        }

        public void Construct(CarBuilder builder)
        {
            _builder = builder;
             
            _builder.BuildEngine();
            _builder.BuildFrame(); 
        }

        // variation: the show method on the director instead of on the product.
        public void Show()
        {
            Console.WriteLine(_builder?.Car.ToString());
        }
    }

    /// <summary>
    /// Builder abstract class
    /// </summary>
    public abstract class CarBuilder
    {
        public Car Car { get; private set; }
         
        public CarBuilder(string carType)
        {
            Car = new Car(carType);
        }
        public abstract void BuildEngine();
        public abstract void BuildFrame(); 
    }

    /// <summary>
    /// ConcreteBuilder1 class
    /// </summary>
    public class MiniBuilder : CarBuilder
    { 
        public MiniBuilder()
            : base("Mini")
        {
        }

        public override void BuildEngine()
        {
            Car.AddPart("'not a V8'");
        }

        public override void BuildFrame()
        {
            Car.AddPart("'3-door with stripes'");
        }
    }

    /// <summary>
    /// ConcreteBuilder2 class
    /// </summary>
    public class BMWBuilder : CarBuilder
    {
        // Invoke base class constructor
        public BMWBuilder()
            : base("BMW")
        {
        }

        public override void BuildEngine()
        {
            Car.AddPart("'a fancy V8 engine'");
        }

        public override void BuildFrame()
        {
            Car.AddPart("'5-door with metallic finish'");
        }
    }
     

    /// <summary>
    /// Product class
    /// </summary>
    public class Car
    {
        private readonly List<string> _parts = new();
        private readonly string _carType;
         
        public Car(string carType)
        {
            _carType = carType;
        }

        public void AddPart(string part)
        {
            _parts.Add(part);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (string part in _parts)
            {
                sb.Append($"Car of type {_carType} has part {part}. "); 
            }

            return sb.ToString();          
        }
    } 



    /// <summary>
    /// The 'Director' class
    /// </summary>
    public class Director
    {
        // Builder uses a complex series of steps
        public void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }

    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    public abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();
    }

    /// <summary>
    /// The 'ConcreteBuilder1' class
    /// </summary>
    public class ConcreteBuilder1 : Builder
    {
        private Product product = new Product();

        public override void BuildPartA()
        {
            product.Add("PartA");
        }

        public override void BuildPartB()
        {
            product.Add("PartB");
        }

        public override Product GetResult()
        {
            return product;
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>
    public class ConcreteBuilder2 : Builder
    {
        private Product product = new Product();

        public override void BuildPartA()
        {
            product.Add("PartX");
        }

        public override void BuildPartB()
        {
            product.Add("PartY");
        }

        public override Product GetResult()
        {
            return product;
        }
    }

    /// <summary>
    /// The 'Product' class
    /// </summary>
    public class Product
    {
        private List<string> parts = new List<string>();

        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("\nProduct Parts -------");
            foreach (string part in parts)
                Console.WriteLine(part);
        }
    }
}
