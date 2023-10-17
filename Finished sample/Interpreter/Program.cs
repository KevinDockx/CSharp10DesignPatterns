using Interpreter;

Console.Title = "Interpreter";

var expressions = new List<RomanExpression>
{
    new RomanHunderdExpression(),
    new RomanTenExpression(),
    new RomanOneExpression(),
};

var context = new RomanContext(5);
foreach (RomanExpression expression in expressions)
{
    expression.Interpret(context);
}
Console.WriteLine($"Translating Arabic numerals to Roman numerals: 5 = {context.Output}");

context = new RomanContext(81);
foreach (RomanExpression expression in expressions)
{
    expression.Interpret(context);
}
Console.WriteLine($"Translating Arabic numerals to Roman numerals: 81 = {context.Output}");

context = new RomanContext(733);
foreach (RomanExpression expression in expressions)
{
    expression.Interpret(context);
}
Console.WriteLine($"Translating Arabic numerals to Roman numerals: 733 = {context.Output}");

Console.ReadKey();