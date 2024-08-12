using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Example string containing potential dates
        string input = "The event is on 08152024 and the backup date is 12252023.";

        // Regular expression to match MMDDYYYY format
        string pattern = @"\b(\d{2})(\d{2})(\d{4})\b";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(input);

        foreach (Match match in matches)
        {
            // Extract potential date
            string month = match.Groups[1].Value;
            string day = match.Groups[2].Value;
            string year = match.Groups[3].Value;
            string dateString = $"{month}{day}{year}";

            // Validate and parse the date
            if (DateTime.TryParseExact(dateString, "MMddyyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                Console.WriteLine($"Valid Date Found: {date.ToShortDateString()}");
            }
            else
            {
                Console.WriteLine($"Invalid Date: {dateString}");
            }
        }
    }
}
