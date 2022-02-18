using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    ///// <summary>
    ///// Visitor
    ///// </summary>
    //public interface IVisitor
    //{
    //    void VisitCustomer(Customer customer);
    //    void VisitEmployee(Employee employee);
    //}

    /// <summary>
    /// Visitor (alternative)
    /// </summary>
    public interface IVisitor
    {
        void Visit(IElement element); 
    }

    /// <summary>
    /// Element
    /// </summary>
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }

    /// <summary>
    /// ConcreteElement
    /// </summary>
    public class Customer : IElement
    {
        public decimal AmountOrdered { get; private set; }
        public decimal Discount { get; set; }
        public string Name { get; private set; }

        public Customer(string name, decimal amountOrdered)
        {
            Name = name;
            AmountOrdered = amountOrdered;
        }
        
        public void Accept(IVisitor visitor)
        {
            // alternative
            // visitor.VisitCustomer(this);
            visitor.Visit(this);
            Console.WriteLine($"Visited {nameof(Customer)} {Name}, discount given: {Discount}");
        }
    }

    /// <summary>
    /// ConcreteElement
    /// </summary>
    public class Employee : IElement
    {
        public int YearsEmployed { get; private set; }
        public decimal Discount { get; set; }
        public string Name { get; private set; }

        public Employee(string name, int yearsEmployed)
        {
            Name = name;
            YearsEmployed = yearsEmployed;
        }

        public void Accept(IVisitor visitor)
        {
            // alternative
            // visitor.VisitEmployee(this);
            visitor.Visit(this);
            Console.WriteLine($"Visited {nameof(Employee)} {Name}, discount given: {Discount}");
        }         
    }

    ///// <summary>
    ///// ConcreteVisitor
    ///// </summary>
    //public class DiscountVisitor : IVisitor
    //{
    //    public decimal TotalDiscountGiven { get; set; }

    //    public void VisitCustomer(Customer customer)
    //    {
    //        // percentage of total amount
    //        var discount = customer.AmountOrdered / 10;
    //        // set it on the customer
    //        customer.Discount = discount;
    //        // add it to the total amount
    //        TotalDiscountGiven += discount;
    //    }

    //    public void VisitEmployee(Employee employee)
    //    {
    //        // fixed value depending on the amount of years employed
    //        var discount = employee.YearsEmployed < 10 ? 100 : 200;
    //        // set it on the employee
    //        employee.Discount = discount;
    //        // add it to the total amount
    //        TotalDiscountGiven += discount;
    //    }
    //}

    /// <summary>
    /// ConcreteVisitor (alternative)
    /// </summary>
    public class DiscountVisitor : IVisitor
    {
        public decimal TotalDiscountGiven { get; set; }

        public void Visit(IElement element)
        {
            if (element is Customer)
            {
                VisitCustomer((Customer)element);
            }
            else if (element is Employee)
            {
                VisitEmployee((Employee)element);
            }
        }

        private void VisitCustomer(Customer customer)
        {
            // percentage of total amount
            var discount = customer.AmountOrdered / 10;
            // set it on the customer
            customer.Discount = discount;
            // add it to the total amount
            TotalDiscountGiven += discount;
        }

        private void VisitEmployee(Employee employee)
        {
            // fixed value depending on the amount of years employed
            var discount = employee.YearsEmployed < 10 ? 100 : 200;
            // set it on the employee
            employee.Discount = discount;
            // add it to the total amount
            TotalDiscountGiven += discount;
        }
    }

    /// <summary>
    /// ObjectStructure
    /// </summary>
    public class Container
    {
        public List<Employee> Employees { get; set; } = new();
        public List<Customer> Customers { get; set; } = new();

        public void Accept(IVisitor visitor)
        {
            foreach (var employee in Employees)
            {
                employee.Accept(visitor);
            }
            foreach (var customer in Customers)
            {
                customer.Accept(visitor);
            } 
        }
    }
}
