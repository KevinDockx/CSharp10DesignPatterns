using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
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
        private char _actualCharacter = 'a';
        private string _fontFamily = string.Empty;
        private int _fontSize;

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
        private char _actualCharacter = 'b';
        private string _fontFamily = string.Empty;
        private int _fontSize;

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
        private readonly Dictionary<char, ICharacter> _characters = new ();

        public ICharacter? GetCharacter(char characterIdentifier)
        { 
            // Coes the character dictionary contain the one we need? 
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

        public ICharacter CreateParagraph(List<ICharacter> characters, int location)
        {
            return new Paragraph(characters, location);
        }
    }

    /// <summary>
    /// Unshared Concrete Flyweight
    /// </summary>
    public class Paragraph : ICharacter
    {
        private int _location;
        private List<ICharacter> _characters = new();

        public Paragraph(List<ICharacter> characters, int location)
        {
            _characters = characters;
            _location = location;
        }

        public void Draw(string fontFamily, int fontSize)
        {
            Console.WriteLine($"Drawing in paragraph at location {_location}");
            foreach (var character in _characters)
            {
                character.Draw(fontFamily, fontSize);
            }  
        }
    }
}
