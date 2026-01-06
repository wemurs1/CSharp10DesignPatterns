namespace Mediator;

// public abstract class ChatRoom
// {
//     public abstract void Register(TeamMember teamMember);
//     public abstract void Send(string from, string message);
// }

/// <summary>
/// Mediator
/// </summary>
public interface IChatRoom
{
    void Register(TeamMember teamMember);
    void Send(string from, string message);
}

/// <summary>
/// Colleague
/// </summary>
public abstract class TeamMember
{
    private IChatRoom? _chatRoom;

    public string Name { get; set; }

    public TeamMember(string name)
    {
        Name = name;
    }

    internal void SetChatRoom(IChatRoom chatRoom)
    {
        _chatRoom = chatRoom;
    }

    public void Send(string message)
    {
        _chatRoom?.Send(Name, message);
    }

    public virtual void Receive(string from, string message)
    {
        Console.WriteLine($"Message {from} to {Name}: {message}");
    }
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
    private readonly Dictionary<string, TeamMember> teamMembers = new();

    public void Register(TeamMember teamMember)
    {
        teamMember.SetChatRoom(this);
        teamMembers.TryAdd(teamMember.Name, teamMember);
    }

    public void Send(string from, string message)
    {
        foreach (var teamMember in teamMembers.Values)
        {
            teamMember.Receive(from, message);
        }
    }
}