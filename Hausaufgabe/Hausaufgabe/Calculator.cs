using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Hausaufgabe
{
    static class Calculator
    {
        internal static int Add(string calcString)
        {
            if (string.IsNullOrEmpty(calcString))
                throw new ArgumentException("Calculationstring can not be empty");
            return GetSumOfStrings(GetNumberStrings(calcString));
        }

        private static int GetSumOfStrings(ICollection<string> numberstrings)
        {
            return numberstrings.Sum(GetNumberFromString);
        }

        private static ICollection<string> GetNumberStrings(string calcString)
        {

            var delimiters = GetDelimiters(calcString);
            var sanitizedCalcString = RemoveCustomDelimiterFromCalcString(calcString);
            if (string.IsNullOrEmpty(sanitizedCalcString))
                throw new ArgumentException("Calculationstring can not be empty");
            return sanitizedCalcString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }

        private static string RemoveCustomDelimiterFromCalcString(string calcString)
        {
            if (calcString.StartsWith("//"))
                return calcString.Substring(calcString.IndexOf(@"\n")+2);
            return calcString;
        }

        private static string[] GetDelimiters(string calcString)
        {
            List<string> delimiters = new List<string>();
            delimiters.Add(",");
            delimiters.Add(@"\n");
            if (calcString.StartsWith("//"))
            {
                int delimiterEndIndex = calcString.IndexOf(@"\n");
                if (delimiterEndIndex == -1)
                    throw new ArgumentException("Delimiter can not be invalid");
                delimiters.Add(calcString.Substring(2, delimiterEndIndex - 2));
            }

            return delimiters.ToArray();
        }

        private static int GetNumberFromString(string numberstring)
        {
            if (!int.TryParse(numberstring, out int number))
                throw new ArgumentException("Number " + numberstring + " is not valid!");
            if (number < 0)
                throw new ArgumentException("Numbers in calculationstring can not be negative!");
            return number;
        }
    }
}
