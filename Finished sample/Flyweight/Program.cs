using Flyweight;

Console.Title = "Flyweight";

var aBunchOfCharacters = "abba";

var characterFactory = new CharacterFactory();

// Get the flyweight(s)
ICharacter? characterObject = characterFactory.GetCharacter(aBunchOfCharacters[0]);
// Pass through extrinsic state
characterObject?.Draw("Arial", 12);

characterObject = characterFactory.GetCharacter(aBunchOfCharacters[1]);
characterObject?.Draw("Trebuchet MS", 14);

characterObject = characterFactory.GetCharacter(aBunchOfCharacters[2]);
characterObject?.Draw("Times New Roman", 16);

characterObject = characterFactory.GetCharacter(aBunchOfCharacters[3]);
characterObject?.Draw("Comic Sans", 18);

// create unshared concrete flyweight (paragraph)
ICharacter paragraph = CharacterFactory.CreateParagraph(
    characterObject is null
        ? new List<ICharacter>(0)
        : new List<ICharacter>() { characterObject }
    , 1);

// draw the paragraph
paragraph.Draw("Lucinda", 12);

Console.ReadKey();