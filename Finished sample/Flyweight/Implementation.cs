namespace Flyweight;

/// <summary>
/// Flyweight
/// </summary>
public interface ICharacter
{
    void Draw(string fontFamily, int fontSize);
}

/// <summary>
/// Concrete Flyweight
/// </summary>
public class CharacterA : ICharacter
{
    readonly char _actualCharacter = 'a';
    string _fontFamily = string.Empty;
    int _fontSize;

    public void Draw(string fontFamily, int fontSize)
    {
        _fontFamily = fontFamily;
        _fontSize = fontSize;
        Console.WriteLine($"Drawing {_actualCharacter}, {_fontFamily} {_fontSize}");
    }
}

/// <summary>
/// Concrete Flyweight
/// </summary>
public class CharacterB : ICharacter
{
    readonly char _actualCharacter = 'b';
    string _fontFamily = string.Empty;
    int _fontSize;

    public void Draw(string fontFamily, int fontSize)
    {
        _fontFamily = fontFamily;
        _fontSize = fontSize;
        Console.WriteLine($"Drawing {_actualCharacter}, {_fontFamily} {_fontSize}");
    }
}

/// <summary>
/// FlyweightFactory
/// </summary>
public class CharacterFactory
{
    readonly Dictionary<char, ICharacter> _characters = new();

    public ICharacter? GetCharacter(char characterIdentifier)
    {
        // Does the character dictionary contain the one we need? 
        if (_characters.ContainsKey(characterIdentifier))
        {
            Console.WriteLine("Character reuse");
            return _characters[characterIdentifier];
        }

        // The character isn't in the dictionary. 
        // Create it, store it, return it.
        Console.WriteLine("Character construction");
        switch (characterIdentifier)
        {
            case 'a':
                _characters[characterIdentifier] = new CharacterA();
                return _characters[characterIdentifier];
            case 'b':
                _characters[characterIdentifier] = new CharacterB();
                return _characters[characterIdentifier];
                // and so on...               
        }

        return null;
    }

    public static ICharacter CreateParagraph(List<ICharacter> characters, int location) => new Paragraph(characters, location);
}

/// <summary>
/// Unshared Concrete Flyweight
/// </summary>
public class Paragraph : ICharacter
{
    readonly int _location;
    readonly List<ICharacter> _characters = new();

    public Paragraph(List<ICharacter> characters, int location)
    {
        _characters = characters;
        _location = location;
    }

    public void Draw(string fontFamily, int fontSize)
    {
        Console.WriteLine($"Drawing in paragraph at location {_location}");
        foreach (ICharacter character in _characters)
        {
            character.Draw(fontFamily, fontSize);
        }
    }
}
