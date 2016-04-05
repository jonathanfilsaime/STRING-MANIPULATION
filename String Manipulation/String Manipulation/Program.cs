using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //reversing the string 
            String str = "The quick brown fox jumps over the lazy dog";
            Console.WriteLine(str);

            Console.WriteLine("after reversed \n");
            String rv = reversString(str);
            Console.WriteLine(rv);

            //swapping numbers 
            int a = 72;
            int b = 59;

            Console.WriteLine("int x = " + a);
            Console.WriteLine("int y = " + b);
            swap(a, b);

            //match regular expression
            String find = "Foo Bar [23,14] Bash";
            match(find);


            //pause the console 
            Console.ReadLine();
        }

        public static String reversString(String str)
        {
            int count = 0;
            String s = str;
            String hold;
            StringBuilder temp = new StringBuilder();
            String[] c = new String[s.Length - 1];


            //read each word and remove white space 
            for (int i = 0; i < s.Length; i++)
            {
                if (s.ElementAt(i) == ' ')
                {
                    i++;
                }
                while ((i < s.Length) && (s.ElementAt(i) != ' '))
                {
                    temp.Append(s.ElementAt(i).ToString());
                    i++;
                }

                hold = temp.ToString();
                temp.Clear();

                c[count] = hold;
                count++;
            }

            //reverse the order of each word and rebuild string 
            for (int i = count - 1; i >= 0; i--)
            {
                if (i != 0)
                {
                    temp.Append(c[i]);
                    temp.Append(' ');
                }
                else
                {
                    temp.Append(c[i]);
                }
            }

            String reverse = temp.ToString();
            return reverse;
        }

        public static void swap(int a, int b)
        {
            int first = a;
            int second = b;

            if (a > b)
            {
                a = a - b;
                b = b + a;
                a = b - a;
            }
            else
            {
                b = b - a;
                a = a + b;
                b = a - b;
            }

            Console.WriteLine("after swap");
            Console.WriteLine("int x = " + a);
            Console.WriteLine("int b = " + b);

        }

        public static void match(String str)
        {
            String str1 = str;
            String pattern = @"\[\d+\,\d+\]";

            //match pattern 
            Match result = Regex.Match(str1, pattern);

            String str2 = "";
            if (result.Success)
            {
                str2 = result.Value;
            }
            else
            {
                Console.WriteLine("No Match");
                return;
            }


            //match number
            String patternNumber = @"\d+";
            Match result1 = Regex.Match(str2, patternNumber);

            //if found assing first number to number 1
            int number1 = 0;
            if (Int32.TryParse(result1.Value, out number1))
            {
            }
            else
            {
                Console.WriteLine("String could not be parsed.");
            }

            result1 = result1.NextMatch();

            //if found assing second number to number 2 
            int number2 = 0;
            if (Int32.TryParse(result1.Value, out number2))
            {
            }
            else
            {
                Console.WriteLine("String could not be parsed.");
            }

            Console.WriteLine("number 1 = " + number1);
            Console.WriteLine("number 2 = " + number2);
        }
    }
}

