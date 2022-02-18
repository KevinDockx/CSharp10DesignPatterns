using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    /// <summary>
    /// Context
    /// </summary>
    public class RomanContext
    {
        public int Input { get; set; }
        public string Output { get; set; } = string.Empty;
        public RomanContext(int input)
        {
            Input = input;
        }
    }

    /// <summary>
    /// AbstractExpression
    /// </summary>
    public abstract class RomanExpression
    {
         public abstract void Interpret(RomanContext value); 
    }

    // 9 = IX
    // 8 = VIII
    // 7 = VII
    // 6 = VI
    // 5 = V
    // 4 = IV
    // 3 = III
    // 2 = II
    // 1 = I

    // simplified - each combination is reachable with substraction and these 4:
    // 9 = IX 
    // 5 = V
    // 4 = IV
    // 1 = I

    /// <summary>
    /// TerminalExpression
    /// </summary>
    public class RomanOneExpression : RomanExpression
    {
        public override void Interpret(RomanContext value)
        {
            while ((value.Input - 9) >= 0)
            {
                value.Output += "IX";
                value.Input -= 9;
            }

            while ((value.Input - 5) >= 0)
            {
                value.Output += "V";
                value.Input -= 5;
            }

            while ((value.Input - 4) >= 0)
            {
                value.Output += "IV";
                value.Input -= 4;
            } 

            while ((value.Input - 1) >= 0)
            {
                value.Output += "I";
                value.Input -= 1;
            }
        }
    }

    // 90 = XC
    // 80 = LIII
    // 70 = LII
    // 60 = LX
    // 50 = L
    // 40 = XL
    // 30 = XXX
    // 20 = XX
    // 10 = X

    // simplified - each combination is reachable with substraction and these 4:
    // 90 = XC 
    // 50 = L
    // 40 = XL
    // 10 = X

    /// <summary>
    /// TerminalExpression
    /// </summary>
    public class RomanTenExpression : RomanExpression
    {
        public override void Interpret(RomanContext value)
        {
            while ((value.Input - 90) >= 0)
            {
                value.Output += "XC";
                value.Input -= 90;
            }

            while ((value.Input - 50) >= 0)
            {
                value.Output += "L";
                value.Input -= 50;
            }

            while ((value.Input - 40) >= 0)
            {
                value.Output += "XL";
                value.Input -= 40;
            }

            while ((value.Input - 10) >= 0)
            {
                value.Output += "X";
                value.Input -= 10;
            }
        }
    }

    // 900 = CM
    // 800 = DCCC
    // 700 = DCC
    // 600 = DC
    // 500 = D
    // 400 = CD
    // 300 = CCC
    // 200 = CC
    // 100 = C

    // simplified - each combination is reachable with substraction and these 4:
    // 900 = CM
    // 500 = D
    // 400 = CD
    // 100 = C

    /// <summary>
    /// TerminalExpression
    /// </summary>
    public class RomanHunderdExpression : RomanExpression
    {
        public override void Interpret(RomanContext value)
        {
            while ((value.Input - 900) >= 0)
            {
                value.Output += "CM";
                value.Input -= 900;
            }

            while ((value.Input - 500) >= 0)
            {
                value.Output += "D";
                value.Input -= 500;
            }

            while ((value.Input - 400) >= 0)
            {
                value.Output += "CD";
                value.Input -= 400;
            }

            while ((value.Input - 100) >= 0)
            {
                value.Output += "C";
                value.Input -= 100;
            }
        }
    }
}
