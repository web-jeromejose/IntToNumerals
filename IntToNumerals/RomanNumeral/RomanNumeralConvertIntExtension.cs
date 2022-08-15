using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntToNumerals
{

    internal static class RomanNumeralConvertIntExtension
    {


        /* 
         Coding Challenge
            Numbers to Roman Numerals Converter
 
        Write code to convert any number between 1 and 2000 to a Roman Numeral, 
        using the standard rules. You can use libraries/packages within reason, but your solution must demonstrate the application of the rules logic you have written.

 

            Your solution will be assessed on whether it: -

            1) solves the problem

            2) is well structured

            3) has an appropriate level of complexity
         */
        internal static string ConvertToRomanNumeral(this int i)
        {

            if (i > 2000)
                return "";

            var sBuilder = new StringBuilder();


            foreach (var range in Ranges())
            {
                var upperLimit = range.IntNumber * 10;
                var count = (i >= upperLimit ? i % upperLimit : i) / range.IntNumber;

                switch (count)
                {
                    case < 4:
                        sBuilder.Append(range.RomanNumerals, count);
                        break;
                    case 4:
                        sBuilder.Append($"{range.RomanNumerals}{range.HalfRomanNumerals}");
                        break;
                    case 5:
                        sBuilder.Append(range.HalfRomanNumerals);
                        break;
                    case 9:
                        sBuilder.Append($"{range.RomanNumerals}{range.MaxRomanNumerals}");
                        break;
                    case > 5:
                        sBuilder.Append(range.HalfRomanNumerals);
                        sBuilder.Append(range.RomanNumerals, count % 5);
                        break;
                }
            }

            return sBuilder.ToString();
        }

        private static List<NumeralFlags> Ranges()
        {
            var numeralRanges = new List<NumeralFlags> {
                new NumeralFlags { IntNumber = 1000, RomanNumerals = 'M' },
                new NumeralFlags { IntNumber = 100, RomanNumerals = 'C', MaxRomanNumerals = 'M', HalfRomanNumerals = 'D' },
                new NumeralFlags { IntNumber = 10, RomanNumerals = 'X', MaxRomanNumerals = 'C', HalfRomanNumerals = 'L' },
                new NumeralFlags { IntNumber = 1, RomanNumerals = 'I', MaxRomanNumerals = 'X', HalfRomanNumerals = 'V' }
            };
            return numeralRanges;
        }


    }
}
