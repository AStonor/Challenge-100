using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BlueFragment
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("CHALLENGE 101");
            try
            {
                var result = FindMinMax(new int[] { 1, 2, 3, 4, 5 });
                Console.WriteLine("[{0}, {1}]", result[0], result[1]);
                result = FindMinMax(new int[] { 2334454, 5 });
                Console.WriteLine("[{0}, {1}]", result[0], result[1]);
                result = FindMinMax(new int[] { 1 });
                Console.WriteLine("[{0}, {1}]", result[0], result[1]);
                result = FindMinMax(new int[0]);
                Console.WriteLine("[{0}, {1}]", result[0], result[1]);

            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();

            Console.WriteLine("CHALLENGE 102");
            Console.WriteLine(NameShuffle("Donald Trump"));
            Console.WriteLine(NameShuffle("Rosie O'Donnell"));
            Console.WriteLine(NameShuffle("Seymour Butts"));
            Console.WriteLine(NameShuffle("Philip Seymour Hoffman"));
            Console.WriteLine();

            Console.WriteLine("CHALLENGE 103");
            Console.WriteLine(SameCase("hello"));
            Console.WriteLine(SameCase("HELLO"));
            Console.WriteLine(SameCase("Hello"));
            Console.WriteLine(SameCase("ketcHUp"));
            Console.WriteLine();

            Console.WriteLine("CHALLENGE 104");
            Console.WriteLine(IsIsogram("Algorism"));
            Console.WriteLine(IsIsogram("PasSword"));
            Console.WriteLine(IsIsogram("Consecutive"));
            Console.WriteLine();

            Console.WriteLine("CHALLENGE 105");
            Console.WriteLine(MonthName(3));
            Console.WriteLine(MonthName(12));
            Console.WriteLine(MonthName(6));
            Console.WriteLine();

            Console.WriteLine("CHALLENGE 106");
            Console.WriteLine(AlphabetIndex("Wow, does that work?"));
            Console.WriteLine(AlphabetIndex("The river stole the gods."));
            Console.WriteLine(AlphabetIndex("We have a lot of rain in June."));
            Console.WriteLine();






        }


        static int[] FindMinMax(int[] array)
        {

            // Jeg ved ikke helt hvad den skal returnere i tilfældet af et tomt array, så jeg bruger en exception som placeholder.

            if (array.Length == 0)
            {
                throw new Exception("The array being parsed is empty and must contain at least 1 value.");
            }

            var minMax = new int[] { Int32.MaxValue, Int32.MinValue };

            foreach(int number in array)
            {
                minMax[0] = Math.Min(minMax[0], number);
                minMax[1] = Math.Max(minMax[1], number);
            }

            return minMax;
        }

        static string NameShuffle(string name)
        {
          
            var nameSeperated = name.Split(' ');

            // Det fremgik ikke af eksemplerne hvad der sker når der er mellemnavne eller mindre end 2 navne. Jeg har prøvet at tage højde for det med en intuitiv udvidet løsning.

            if (nameSeperated.Length < 2)
            {
                return name;
            }

            var firstName = nameSeperated[0];
            var lastName = nameSeperated[nameSeperated.Length - 1];
            var middleNames = name.Substring(firstName.Length, name.Length - firstName.Length - lastName.Length);

            return String.Concat(lastName, middleNames, firstName);

        }

        static bool SameCase(string input)
        {
            return input.ToLower().Equals(input) || input.ToUpper().Equals(input); 
        }



        static bool IsIsogram(string input)
        {
            var uniqueChars = input.ToLower().Distinct();

            return uniqueChars.Count() == input.Length ? true : false;

        }

        static string MonthName(int monthNumber)
        {

            return CultureInfo.GetCultureInfo("en-GB").DateTimeFormat.GetMonthName(monthNumber);

        }

        static string AlphabetIndex(string input)
        {
     
            string output = "";

            foreach (char letter in input.ToLower())
            {
                // For at gøre det mest simpelt, holder jeg mig til det engelske alfabet. Det har også den fordel at det bliver encoded ens over de fleste encoding formater.

                if (letter > 96 && letter < 123)
                {
                    output += String.Format("{0} ", (int)(letter - 96));
                }
            }

            return output;

        }
    }
}
