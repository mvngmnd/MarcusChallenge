using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace TechOne.Controllers
{
    public static class BankHelper
    {

        private static Dictionary<ulong, string> singleDigits = new Dictionary<ulong, string>{
                {0, "Zero"}, {1, "One"},
                {2, "Two"}, {3, "Three"},
                {4, "Four"}, {5, "Five"},
                {6, "Six"}, {7, "Seven"},
                {8, "Eight"}, {9, "Nine"}
            };

        private static Dictionary<ulong, string> doubleDigits = new Dictionary<ulong, string>{
                {11, "Eleven"},
                {12, "Twelve"},
                {13, "Thirteen"},
                {14, "Fourteen"},
                {15, "Fifteen"},
                {16, "Sixteen"},
                {17, "Seventeen"},
                {18, "Eighteen"},
                {19, "Nineteen"},
            };

        private static Dictionary<ulong, string> tens = new Dictionary<ulong, string>{
                {10, "Ten"},
                {20, "Twenty"},
                {30, "Thirty"},
                {40, "Forty"},
                {50, "Fifty"},
                {60, "Sixty"},
                {70, "Seventy"},
                {80, "Eighty"},
                {90, "Ninety"},
            };

        private static Dictionary<ulong, string> powersOfTen = new Dictionary<ulong, string>{
                {(ulong) Math.Pow(10, 2), "Hundred"},
                {(ulong) Math.Pow(10, 3), "Thousand"},
                {(ulong) Math.Pow(10, 6), "Million"},
                {(ulong) Math.Pow(10, 9), "Billion"},
                {(ulong) Math.Pow(10, 12), "Trillion"},
                {(ulong) Math.Pow(10, 15), "Quadrillion"},
                {(ulong) Math.Pow(10, 18), "Quintillion"}   // ulong max, ~18.4 quintillion 
            };

        private static Dictionary<ulong, string> all = singleDigits.Concat(doubleDigits).Concat(tens).ToDictionary(
                x => x.Key, x => x.Value
            );

        
        private static string denomTrick(ulong value, ulong denom) {
            // Means something like 102 thousand. So split that into the
            // one hundred and three, and the thousand.
            var rem = value%denom;

            var showAnd = rem < (denom / (ulong) 10) 
                || (denom == (ulong) 100);

            var sb = new StringBuilder();

            // The one hundred and two
            sb.Append(NumberToString(value/denom));
            // The thousand
            sb.Append($" {powersOfTen[denom]} ");

            
            if (rem > 0){
                if (showAnd) {
                    sb.Append(" and ");
                }

                // Whatever remainer is left.
                sb.Append(NumberToString(rem));
            }

            return sb.ToString().Trim();

        }

        public static string NumberToString(ulong value)
        {
            // Some base cases for recursion. 

            // Check if we are a basic value, like ten, or a thousand.
            if (all.ContainsKey(value)){
                return all[value];
            }

            // Check if we are a simple multiple, like three thousand.
            var multiple = powersOfTen.Reverse()            // Reverse because we prefer higher multiples
                .Where( x => value/x.Key < 100)             // Remove the posibility of a million being one thousand thousand
                .FirstOrDefault(x => value % x.Key == 0);   

            if (multiple.Key != 0 && !(multiple.Value == "Hundred" && value/multiple.Key > 10)){
                var num = value / multiple.Key;
                return $"{NumberToString(num)} {multiple.Value}";
            }

            // Lets check if we can do something like "one hundred and two" + "thousand"
            var denom = (ulong) Math.Pow(10,value.ToString().Length-1);
            var denomsBelow = new ulong[] {denom/10, denom/100};
            foreach (var val in denomsBelow){
                if (powersOfTen.ContainsKey(val) && powersOfTen[val] != "Hundred"){
                    return denomTrick(value, val);
                }
            }

            // Couldnt do any of above... lets split out what we have.
            var rem = value%denom;
            var showAnd = rem < (denom / (ulong) 10) 
                    || (denom == (ulong) 100);

            return $"{NumberToString(value - rem)} {(showAnd?"and ": "")}{NumberToString(rem)}";

        }
    }
}
