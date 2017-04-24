using System;
using System.Collections.Generic;
using System.Linq;

namespace TextMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;

            string subtext = string.Empty;


            Console.Write("The input text is (Ctrl-C to exit): ");
            text = Console.ReadLine();
            
            while (text !=null) {
                
                Console.Write("Subtext  (Ctrl-C to exit): ");
                subtext = Console.ReadLine();

                if (subtext == null) {
                    break;
                }

                try
                {
                    MatchText(text, subtext);
                }
                catch (Exception exp) {

                    Console.WriteLine("An error occurred: " + exp.Message);
                }
            }
        }

        public static void MatchText(string text, string subtext) {
            var matchedIndexArray = new List<int>();

            if (text.Length < subtext.Length)
            {
                Console.WriteLine("<no matches>");
                return;
            }

            if (subtext.Length == 0) {
                Console.WriteLine("<no matches>");
                return;
            }

            char[] tArray = text.ToUpper().ToArray();
            char[] stArray = subtext.ToUpper().ToArray();
            for (int i = 0; i < tArray.Length; i++)
            {

                if (tArray[i] == stArray[0])
                {

                    bool matched = true;
                    for (int j = 1; j < stArray.Length; j++)
                    {
                        if (stArray[j] != tArray[i + j])
                        {
                            matched = false;
                            break;
                        }
                    }

                    if (matched)
                    {

                        matchedIndexArray.Add(i + 1);
                    }
                }
            }

            Console.Write("Output: ");
            int count = 0;
            if (matchedIndexArray.Count > 0)
            {
                foreach (var num in matchedIndexArray)
                {
                    if (count > 0)
                    {
                        Console.Write(", ");
                    }
                    Console.Write(num.ToString());

                    count++;
                }
            }
            else
            {
                Console.Write("<no matches>");
            }

            Console.WriteLine();
            matchedIndexArray = new List<int>();
        }
    }
}
