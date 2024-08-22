using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace ESGTestCSharp
{
    class Program
    {
        static int Add(string numbers)
        {
            // Handle empty input
            if (string.IsNullOrWhiteSpace(numbers))
            {
                Console.WriteLine(0);
                return 0;
            }

            List<string> delimiters = new List<string> { ",", "\n" }; // Default delimiters

            // Check for custom delimiters in the format "//[delimiter1][delimiter2]\n"
            if (numbers.StartsWith("//"))
            {
                int newlineIndex = numbers.IndexOf('\n');
                string delimiterSection = numbers.Substring(2, newlineIndex - 2);

                // Find delimiters enclosed in square brackets []
                var matches = Regex.Matches(delimiterSection, @"\[(.*?)\]");

                // Add each delimiter to the list
                foreach (Match match in matches)
                {
                    delimiters.Add(Regex.Escape(match.Groups[1].Value)); // Escape for regex
                }

                // Remove the delimiter definition part from the input
                numbers = numbers.Substring(newlineIndex + 1);
            }

            // Combine delimiters into a single regex pattern
            string delimiterPattern = string.Join("|", delimiters);

            // Split numbers using the regex pattern for delimiters
            string[] numberList = Regex.Split(numbers, delimiterPattern);

            List<int> convertedList = new List<int>();
            foreach (var number in numberList)
            {
                if (int.TryParse(number, out var converted))
                {
                    if (converted < 1000)
                    {
                        convertedList.Add(converted);
                    }
                }
                else if (!string.IsNullOrEmpty(number))
                {
                    Console.WriteLine("Invalid number format: " + number);
                }
            }

            // Calculate the sum
            int sum = convertedList.Sum();
            Console.WriteLine(sum);
            return sum;
        }

        static void Main(string[] args)
        {
            // Call the static method
            var number = Add("1");
            Add("");
            Add("1,2");
            Add("1,2,3");
            Add("1,2\n3\n4");
            Add("//[|||]\n1|||2|||3");
            Add("//[|][%]\n1|2%3");
            Add("//[|][%][*]\n1|2%3*17");


        }
    }

}
// namespace ESGTestCSharp
// {
//     class Program
//     {
//         static int Add(string numbers)
//         {
//             // Check for negative numbers before processing
//             if (numbers.Contains('-'))
//             {
//                 Console.WriteLine("Negatives not allowed: " + numbers);
//                 return 0;
//             }

//             // Handle empty input
//             if (string.IsNullOrWhiteSpace(numbers))
//             {
//                 Console.WriteLine(0);
//                 return 0;
//             }

//             // Handle single number input
//             if (numbers.Length == 1)
//             {
//                 var convertedNumber = Int32.Parse(numbers);
//                 if (convertedNumber < 1000)
//                 {
//                     Console.WriteLine(convertedNumber);
//                     return convertedNumber;
//                 }
//                 else
//                 {
//                     Console.WriteLine(0);
//                     return 0;
//                 }
//             }

//             // Handle multiple numbers with delimiters
//             var delimiters = new[] { ',', '\n', '/', '[' };
//             string[] numberList = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

//             List<int> convertedList = new List<int>();
//             foreach (var number in numberList)
//             {
//                 if (int.TryParse(number, out var converted))
//                 {
//                     if (converted < 1000)
//                     {
//                         convertedList.Add(converted);
//                     }
//                 }
//                 else
//                 {
//                     Console.WriteLine("Invalid number format: " + number);
//                 }
//             }

//             int sum = convertedList.Sum();
//             Console.WriteLine(sum);
//             return sum;
//         }
//         static void Main(string[] args)
//         {
//             // Call the static method
//             var number = Add("1");
//             Add("");
//             Add("1,2");
//             Add("1,2,3");
//             Add("1,2\n3\n4");
//             Add("10;2");
//             Add("//[|||]\n1|||2|||3");


//         }
//    }

// }

// namespace ESGTestCSharp
// {
//     class Program
//     {
//         // Make the method static so it can be called from Main
//         static int add(string numbers)
//         { 
//             if (numbers.Contains('-'))
//             {
//                 Console.WriteLine
//                 return null
//             }
//             if (numbers == "")
//             {
//                 Console.WriteLine(0);
//                 return 0;
//             }if (numbers.Length > 1)
//             {
//              string[]  numbersList = numbers.Split(',', '\n', ';');
//              List<int> convertedList = new List<int>();
//                 foreach (var number in numbersList)
//                 {
//                     var converted = Int32.Parse(number);
//                     convertedList.Add(converted);
//                 }
//                 int sum = convertedList.Sum();
//                 Console.WriteLine(sum);
//                 return sum;

//             }else
//             {
//               // Parse the string to an integer
//             var convertedNumber = Int32.Parse(numbers);

//             // Print the converted number
//             Console.WriteLine(convertedNumber);

//             // Return the converted number
//             return convertedNumber;  
//             }

//         }

//         static void Main(string[] args)
//         {
//             // Call the static method
//             var number = add("1");
//             add("");
//             add("1,2");
//             add("1,2,3");
//             add("1,2\n3\n4");
//             add("10;2");

//             Console.WriteLine(number + 1);
//             Console.WriteLine("1");
//         }
//     }
// }