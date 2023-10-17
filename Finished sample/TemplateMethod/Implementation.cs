namespace TemplateMethod;

/// <summary>
/// AbstractClass
/// </summary>
public abstract class MailParser
{
    public virtual void FindServer() => Console.WriteLine("Finding server...");

    public abstract void AuthenticateToServer();

    public static string ParseHtmlMailBody(string identifier)
    {
        Console.WriteLine("Parsing HTML mail body...");
        return $"This is the body of mail with id {identifier}";
    }

    /// <summary>
    /// Template method
    /// </summary>
    public string ParseMailBody(string identifier)
    {
        Console.WriteLine("Parsing mail body (in template method)...");
        FindServer();
        AuthenticateToServer();
        return ParseHtmlMailBody(identifier);
    }
}

public class ExchangeMailParser : MailParser
{
    public override void AuthenticateToServer() => Console.WriteLine("Connecting to Exchange");
}

public class ApacheMailParser : MailParser
{
    public override void AuthenticateToServer() => Console.WriteLine("Connecting to Apache");
}

public class EudoraMailParser : MailParser
{
    public override void FindServer() => Console.WriteLine("Finding Eudora server through a custom algorithm...");
    public override void AuthenticateToServer() => Console.WriteLine("Connecting to Eudora");
}
