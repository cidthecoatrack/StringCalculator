using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string Addends)
        {
            if (String.IsNullOrEmpty(Addends)) return 0;
            ValidateAddends(Addends);

            int Sum = 0;
            foreach (int addend in ParseAddends(Addends, GetCustomDelimiter(ref Addends)))
                Sum += addend;

            return Sum;
        }

        private List<int> ParseAddends(string Addends, char CustomDelimiter)
        {
            string[] addendsStringArray = Addends.Split(',', '\n', CustomDelimiter);
            List<int> ParsedAddends = new List<int>();
            
            foreach (string StringAddend in addendsStringArray)
                ParsedAddends.Add(Int32.Parse(StringAddend));

            return ParsedAddends;
        }

        private static char GetCustomDelimiter(ref string Addends)
        {
            char CustomDelimiter = ',';
            if (Addends.StartsWith("//"))
            {
                CustomDelimiter = Addends[2];
                Addends = Addends.Remove(0, 4);
            }
            return CustomDelimiter;
        }

        private void ValidateAddends(string Addends)
        {
            char CustomDelimiter = GetCustomDelimiter(ref Addends);
            string[] AddendArray = Addends.Split(',', '\n', CustomDelimiter);
            string message = "Negatives not allowed: ";
            bool FoundInvalidNumber = false;
            foreach (string AddendString in AddendArray)
            {
                if (Int32.Parse(AddendString) < 0)
                {
                    message += " " + Int32.Parse(AddendString);
                    FoundInvalidNumber = true;
                }
            }

            if (FoundInvalidNumber)
                throw new ArgumentException(message);
        }
    }
}