using System;

namespace Numbers2Words
{
    class WordConverter
    {
        // Arrays for single digits, teen numbers, and tens place values
        private static readonly string[] SingleDigits = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        private static readonly string[] TeenNumbers = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
                                                         "Seventeen", "Eighteen", "Nineteen" };
        private static readonly string[] TensPlace = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        // Method to convert a number to words
        public static string NumberToWords(int num)
        {
            if (num == 0) return "Zero";
            if (num < 10) return SingleDigits[num]; // Convert single digit numbers
            if (num < 20) return TeenNumbers[num - 10]; // Convert teen numbers
            if (num < 100) return TensPlace[num / 10] + (num % 10 > 0 ? " " + NumberToWords(num % 10) : ""); // Convert tens and units
            if (num < 1000) return SingleDigits[num / 100] + " Hundred" + (num % 100 > 0 ? " and " + NumberToWords(num % 100) : ""); // Convert hundreds

            // Convert thousands
            return SingleDigits[num / 1000] + " Thousand" + (num % 1000 > 0 ? " " + NumberToWords(num % 1000) : "");
        }

        static void Main()
        {
            // Prompt user for input
            Console.Write("Enter a number (0 to 9999): ");
            int userInput;

            // Validate user input
            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 0 || userInput > 9999)
            {
                Console.Write("Invalid input. Please enter a number between 0 and 9999: ");
            }

            // Convert and display the number in words
            Console.WriteLine(NumberToWords(userInput));
        }
    }
}


