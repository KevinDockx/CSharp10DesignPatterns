namespace Mediator;

//public abstract class ChatRoom
//{
//    public abstract void Register(TeamMember teamMember);
//    public abstract void Send(string from, string message);
//}

/// <summary>
/// Mediator
/// </summary>
public interface IChatRoom
{
    void Register(TeamMember teamMember);
    void Send(string from, string message);
    void Send(string from, string to, string message);
    void SendTo<T>(string from, string message) where T : TeamMember;
}

/// <summary>
/// Colleague
/// </summary>
public abstract class TeamMember
{
    IChatRoom? _chatroom;
    public string Name { get; set; }
    protected TeamMember(string name) => Name = name;

    internal void SetChatroom(IChatRoom chatRoom) => _chatroom = chatRoom;
    public void Send(string to, string message) => _chatroom?.Send(Name, to, message);

    public void SendTo<T>(string message) where T : TeamMember => _chatroom?.SendTo<T>(Name, message);

    public void Send(string message) => _chatroom?.Send(Name, message);

    public virtual void Receive(string from, string message) => Console.WriteLine($"Message {from} to {Name}: {message}");
}

/// <summary>
/// ConcreteColleague
/// </summary>
public class Lawyer : TeamMember
{
    public Lawyer(string name) : base(name)
    {
    }

    public override void Receive(string from, string message)
    {
        Console.WriteLine($"{nameof(Lawyer)} {Name} received: ");
        base.Receive(from, message);
    }
}

/// <summary>
/// ConcreteColleague
/// </summary>
public class AccountManager : TeamMember
{
    public AccountManager(string name) : base(name)
    {
    }

    public override void Receive(string from, string message)
    {
        Console.WriteLine($"{nameof(AccountManager)} {Name} received: ");
        base.Receive(from, message);
    }
}

/// <summary>
/// ConcreteMediator
/// </summary>
public class TeamChatRoom : IChatRoom
{
    readonly Dictionary<string, TeamMember> teamMembers = new();

    public void Register(TeamMember teamMember)
    {
        teamMember.SetChatroom(this);
        if (!teamMembers.ContainsKey(teamMember.Name))
        {
            teamMembers.Add(teamMember.Name, teamMember);
        }
    }

    public void Send(string from, string message)
    {
        foreach (TeamMember teamMember in teamMembers.Values)
        {
            teamMember.Receive(from, message);
        }
    }

    public void Send(string from, string to, string message)
    {
        TeamMember teamMember = teamMembers[to];
        teamMember?.Receive(from, message);
    }

    public void SendTo<T>(string from, string message) where T : TeamMember
    {
        foreach (T teamMember in teamMembers.Values.OfType<T>())
        {
            teamMember.Receive(from, message);
        }
    }
}
