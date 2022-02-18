namespace Memento
{
    /// <summary>
    /// ICommand
    /// </summary>
    public interface ICommand
    {
        void Execute();
        bool CanExecute();
        void Undo();
    }

    /// <summary>
    /// Memento
    /// </summary>
    public class AddEmployeeToManagerListMemento
    {
        public int ManagerId { get; private set; }
        public Employee? Employee { get; private set; }

        public AddEmployeeToManagerListMemento(int managerId, Employee? employee)
        {
            ManagerId = managerId;
            Employee = employee;
        }
    }

    /// <summary>
    /// ConcreteCommand
    /// </summary>
    public class AddEmployeeToManagerList : ICommand
    {
        private readonly IEmployeeManagerRepository _employeeManagerRepository;
        private int _managerId;
        private Employee? _employee;

        public AddEmployeeToManagerList(
            IEmployeeManagerRepository employeeManagerRepository,
            int managerId,
            Employee? employee)
        {
            _employeeManagerRepository = employeeManagerRepository;
            _managerId = managerId;
            _employee = employee;
        }

        public AddEmployeeToManagerListMemento CreateMemento()
        {
            return new AddEmployeeToManagerListMemento(_managerId, _employee);
        }

        public void RestoreMemento(AddEmployeeToManagerListMemento memento)
        {
            _managerId = memento.ManagerId;
            _employee = memento.Employee;
        }

        public bool CanExecute()
        {
            // potentially check against business/technical rules that might block execution

            // employee shouldn't be null
            if (_employee == null)
            {
                return false;
            }

            // employee shouldn't be on the manager's list already
            if (_employeeManagerRepository.HasEmployee(_managerId, _employee.Id))
            {
                return false;
            }

            // other potential rule(s): ensure that an employee can only be added to  
            // one manager's list at the same time, etc.
            return true;
        }

        public void Execute()
        {
            if (_employee == null)
            {
                return;
            }

            _employeeManagerRepository.AddEmployee(_managerId, _employee);
        }

        public void Undo()
        {
            if (_employee == null)
            {
                return;
            }

            _employeeManagerRepository.RemoveEmployee(_managerId, _employee);
        }
    }

    /// <summary>
    /// CareTaker (and Invoker from the Command pattern)
    /// </summary>
    public class CommandManager
    {
        private readonly Stack<AddEmployeeToManagerListMemento> _mementos = new ();
        private AddEmployeeToManagerList? _command;

        public void Invoke(AddEmployeeToManagerList command)
        {
            // if the command has not been stored yet, store it - we will
            // reuse it instead of storing different instances

            if (_command == null)
            {
                _command = command;
            }

            if (command.CanExecute())
            {
                command.Execute();
                _mementos.Push(command.CreateMemento());
            }
        }

        public void Undo()
        {
            if (_mementos.Any())
            {
                _command?.RestoreMemento(_mementos.Pop());
                _command?.Undo(); 
            }
        }

        public void UndoAll()
        {
            while (_mementos.Any())
            {
                _command?.RestoreMemento(_mementos.Pop());
                _command?.Undo();
            }
        }
    }



    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class Manager : Employee
    {
        public List<Employee> Employees = new();
        public Manager(int id, string name)
            : base(id, name)
        {
        }
    }

    /// <summary>
    /// Receiver (interface)
    /// </summary>
    public interface IEmployeeManagerRepository
    {
        void AddEmployee(int managerId, Employee employee);
        void RemoveEmployee(int managerId, Employee employee);
        bool HasEmployee(int managerId, int employeeId);
        void WriteDataStore();
    }

    /// <summary>
    /// Receiver (implementation)
    /// </summary>
    public class EmployeeManagerRepository : IEmployeeManagerRepository
    {
        // for demo purposes, use an in-memory datastore as a fake "manager list"
        private List<Manager> _managers = new List<Manager>()
            { new Manager(1, "Katie"), new Manager(2, "Geoff") };

        public void AddEmployee(int managerId, Employee employee)
        {
            // in real-life, add additional input & error checks
            _managers.First(m => m.Id == managerId).Employees.Add(employee);
        }

        public void RemoveEmployee(int managerId, Employee employee)
        {
            // in real-life, add additional input & error checks
            _managers.First(m => m.Id == managerId).Employees.Remove(employee);
        }

        public bool HasEmployee(int managerId, int employeeId)
        {
            // in real-life, add additional input & error checks
            return _managers.First(m => m.Id == managerId).Employees.Any(e => e.Id == employeeId);
        }


        /// <summary>
        /// For demo purposes, write out the data store to the console window
        /// </summary>
        public void WriteDataStore()
        {
            foreach (var manager in _managers)
            {
                Console.WriteLine($"Manager {manager.Id}, {manager.Name}");
                if (manager.Employees.Any())
                {
                    foreach (var employee in manager.Employees)
                    {
                        Console.WriteLine($"\t Employee {employee.Id}, {employee.Name}");
                    }
                }
                else
                {
                    Console.WriteLine($"\t No employees.");
                }
            }
            Console.WriteLine();
        }
    }
}