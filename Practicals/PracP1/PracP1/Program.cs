using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracP1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            string s = "";

            //check if 2 args
            if (args.Length == 2)
            {
                if (int.TryParse(args[0], out n))
                {
                    //successful parse, so use n
                    s = args[1]; //second argument is character

                    //draw a line of characters
                    DrawChars(n, s);
                }
                else
                {
                    //unsuccessful parse, so no n value
                }
            }

            //wait for user to have read output
            Console.WriteLine();
            Console.Write("Press enter to finish:");
            Console.ReadLine();
        }
        /// <summary>
        /// Method to draw a line of characters
        /// </summary>
        /// <param name="n">number of characters to draw</param>
        /// <param name="s">character to draw n times</param>
        static void DrawChars(int n, string s)
        {
            for (int j = 0; j < n; j++) 
            {
                for (int i = 0; i < n; i++)
                {
                    if (j == i)
                    {
                        Console.Write(((j + 1) % 10).ToString());
                    }
                    else
                    {
                        Console.Write(s);
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
