﻿namespace Command;

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
    readonly List<Manager> _managers = new()
        { new Manager(1, "Katie"), new Manager(2, "Geoff") };

    public void AddEmployee(int managerId, Employee employee) =>
        // in real-life, add additional input & error checks
        _managers.First(m => m.Id == managerId).Employees.Add(employee);

    public void RemoveEmployee(int managerId, Employee employee) =>
        // in real-life, add additional input & error checks
        _managers.First(m => m.Id == managerId).Employees.Remove(employee);

    public bool HasEmployee(int managerId, int employeeId) =>
        // in real-life, add additional input & error checks
        _managers.First(m => m.Id == managerId)
            .Employees.Any(e => e.Id == employeeId);

    /// <summary>
    /// For demo purposes, write out the data store to the console window
    /// </summary>
    public void WriteDataStore()
    {
        foreach (Manager manager in _managers)
        {
            Console.WriteLine($"Manager {manager.Id}, {manager.Name}");
            if (manager.Employees.Any())
            {
                foreach (Employee employee in manager.Employees)
                {
                    Console.WriteLine($"\t Employee {employee.Id}, {employee.Name}");
                }
            }
            else
            {
                Console.WriteLine("\t No employees.");
            }
        }
    }
}

/// <summary>
/// Command
/// </summary>
public interface ICommand
{
    void Execute();
    bool CanExecute();
    void Undo();
}

/// <summary>
/// ConcreteCommand
/// </summary>
public class AddEmployeeToManagerList : ICommand
{
    readonly IEmployeeManagerRepository _employeeManagerRepository;
    readonly int _managerId;
    readonly Employee? _employee;

    public AddEmployeeToManagerList(
        IEmployeeManagerRepository employeeManagerRepository,
        int managerId,
        Employee? employee)
    {
        _employeeManagerRepository = employeeManagerRepository;
        _managerId = managerId;
        _employee = employee;
    }

    public bool CanExecute()
    {
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
/// Invoker
/// </summary>
public class CommandManager
{
    readonly Stack<ICommand> _commands = new();

    public void Invoke(ICommand command)
    {
        if (command.CanExecute())
        {
            command.Execute();
            _commands.Push(command);
        }
    }

    public void Undo()
    {
        if (_commands.TryPop(out ICommand? cmd))
        {
            cmd.Undo();
        }
    }

    public void UndoAll()
    {
        while (_commands.TryPop(out ICommand? cmd))
        {
            cmd.Undo();
        }
    }
}