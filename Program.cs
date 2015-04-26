using System;
using System.Text.RegularExpressions;

namespace hrUtopian_Identification_Number
{
    class Program
    {
        static void Main()
        {
            var regex = new Regex(@"([a-z]{0,3})(\d{2,8})([A-Z]{3,})", RegexOptions.Compiled);
            var regex1 = new Regex(@"^[a-z]{0,3}$", RegexOptions.Compiled);
            var regex2 = new Regex(@"^\d{2,8}$", RegexOptions.Compiled);
            var regex3 = new Regex(@"[A-Z]{3,}$", RegexOptions.Compiled);
            var numCases = Int32.Parse(Console.ReadLine());
            while (numCases-- > 0)
            {
                bool valid = true;
                var str = Console.ReadLine();
                var match = regex.Match(str);
                if (match.Groups.Count != 4) valid = false;
                var firstPart = match.Groups[1].Value;
                var secondPart = match.Groups[2].Value;
                var thirdPart = match.Groups[3].Value;
                bool allCharsCaptured =
                    firstPart.Length +
                    secondPart.Length +
                    thirdPart.Length == str.Length;
                if (!allCharsCaptured) valid = false;
                if (valid)
                {
                    valid = regex1.IsMatch(firstPart);
                }
                if (valid)
                {
                    valid = regex2.IsMatch(secondPart);
                }
                if (valid)
                {
                    valid = regex3.IsMatch(thirdPart);
                }
                Console.WriteLine(valid ? "VALID" : "INVALID");
            }
        }
    }
}
