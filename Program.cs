using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the Moves of Robot:");
            string moves = Console.ReadLine();
            bool pos = Question1.JudgeCircle(moves);
            if (pos)
            {
                Console.WriteLine("The Robot return’s to initial Position (0,0)");
            }
            else
            {
                Console.WriteLine("The Robot doesn’t return to the Initial Postion (0,0)");
            }
            Console.WriteLine();

            // Question2
            Console.WriteLine(" Q2: Enter the string to check for pangram:");
            string str = Console.ReadLine();
            bool flag = Question2.CheckIfPangram(str);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3
            int[] nums = { 1, 2, 3, 1, 1, 3 };
            int gp = Question3.NumIdenticalPairs(nums);
            Console.WriteLine("Q3:");
            Console.WriteLine("The number of IdenticalPairs in the array are {0}:", gp);

            //Question 4
            int[] arr1 = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4:");
            int pivot = Question4.PivotIndex(arr1);
            if (pivot > 0)
            {
                Console.WriteLine("The Pivot index for the given array is {0}", pivot);
            }
            else
            {
                Console.WriteLine("The given array has no Pivot index");
            }
            Console.WriteLine();

            //Question 5
            Console.WriteLine("Q5:");
            Console.WriteLine("Enter the First Word:");
            String word1 = Console.ReadLine();
            Console.WriteLine("Enter the Second Word:");
            String word2 = Console.ReadLine();
            String merged = Question5.merge(word1, word2);
            Console.WriteLine("The Merged Sentence fromed by both words is {0}", merged);

            //Question 6
            Console.WriteLine("Q6: Enter the sentence to convert:");
            string sentence = Console.ReadLine();
            string goatLatin = Question6.ToGoatLatin(sentence);
            Console.WriteLine("Goat Latin for the Given Sentence is {0}", goatLatin);
            Console.WriteLine();

        }
    }
    class Question1
    {
        public static bool JudgeCircle(string moves)
        {
            try
            {
                int x = 0;
                int y = 0;

                char[] array = moves.ToCharArray();

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == 'R')
                        x++;
                    else if (array[i] == 'L')
                        x--;
                    else if (array[i] == 'U')
                        y++;
                    else if (array[i] == 'D')
                        y--;
                }
                return (x == 0 && y == 0);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
    /* LOGIC: We have considered that the robot initially starts at the origin (0,0) I have declared the initial moves of the robot as 0,0 in this case
     the values are stored in an array and this array has increment variables declared in a for loop and increment the x and y coordinate values accordingly 
    based on the values provided by the user it would return values and would return us the final position of the robot and let us know if it has reached the initial position*/
    public class Question2
    {
        public static bool CheckIfPangram(string str)
        {
            try
            {
                return (str.GroupBy(i => i).Count() == 26);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }

    /*LOGIC: In this scenario we have considered the option of storing the string provided by the user in the variable "CheckIfPangram" the string provided by the user is grouped together
     * using the group by function and is compared to the count, if it is equal to 26 after being grouped based on a key value, else an exception is occured if it fails in the loop,
     post the evaluation of a valid block execution it returns the value either in the parent class "Question2" if the given value is a pangram or not.*/
    class Question3
    {
        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                int count = 0;
                int len = nums.Length;
                for (int i = 0; i < len - 1; i++)
                {
                    for (int j = i + 1; j < len; j++)
                    {
                        if (nums[i] == nums[j])
                        {
                            count++;
                        }
                    }
                }
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    /* LOGIC: We consider 2 indices i,j and try to form good pairs based on the user input, here we store it as the array the value len is the length of the array
     and we run through the entire array given starting with a 0 index and for i we go all the way until len-1 and len for j. If nums[i]=nums[j] then we would increase the count variable
    and return it to check the number of good pairs.*/
    class Question4
    {
        public static int PivotIndex(int[] nums)
        {
            try
            {
                if (nums.Length == 0) return -1;

                int sl = 0, sr = nums.Sum() - nums[0];

                if (sl == sr) return 0;

                for (var i = 1; i < nums.Length; i++)
                {
                    sl += nums[i - 1];

                    sr -= nums[i];

                    if (sl == sr) return i;
                }

                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message);
                throw;

            }
        }

    }
    /*LOGIC: Here the PivotIndex is defined by nums and if the length of nums = 0 then we return -1. sl (sum of left to pivot index) is defined as 0 and 
     sr is defined as the sum to the right of index - the pivot index, if both the variables are equal then we return 0. The variable i is used to navigate through the array
    now comparing it through the entire array, if sl=sr then we return the value i to be the pivot index*/
    class Question5
    {
        public static string merge(string 1word, string 2word)
        {
            try
            {
                var sb = new StringBuilder();
                for (int i = 0; i < Math.Min(1word.Length, 2word.Length); i++)
                {
                    sb.Append(1word[i]);
                    sb.Append(2word[i]);
                }
                if (1word.Length > 2word.Length)
                {
                    sb.Append(1word.Substring(Math.Min(1word.Length, 2word.Length)));
                }
                else
                {
                    sb.Append(2word.Substring(Math.Min(1word.Length, 2word.Length)));
                }
                return sb.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;

            }
        }
    }
    /*LOGIC: In the above code we merge two strings word1 and word2, we have a variable sb stored in the stringbuilder function, we then calculate the length of the two strings
     where the calculation of the length begins from 0 (i=0), the strings are appended using the append function, the lengths fof the two strings are compared
    if the word1.length is greater than word2.length then the strings are appended based on their initial values using the math.min function, the string comparisons are stored using the ToString function.*/
    class Question6
    {
        public static string ToGoatLatin(string word)
        {
            try
            {
                var words = word.Split(' ');
                StringBuilder sb = new StringBuilder();
                int count = 0;
                foreach (string w in words)
                {
                    count++;
                    // if the word starts from vowel
                    if (
                        w[0] == 'a' || w[0] == 'e' || w[0] == 'i' || w[0] == 'o' || w[0] == 'u' ||
                        w[0] == 'A' || w[0] == 'E' || w[0] == 'I' || w[0] == 'O' || w[0] == 'U'
                      )
                    {
                        sb.Append(w);
                    }
                    // if the word is a consonant
                    else
                    {
                        for (int i = 1; i < w.Length; i++)
                            sb.Append(w[i]);
                        // append first word in the end
                        sb.Append(w[0]);
                    }
                    //converting it to the goat thing
                    sb.Append("ma");

                    for (int i = 0; i < count; i++)
                        sb.Append('a');
                    // skip space for the last word
                    if (count < words.Length)
                        sb.Append(' ');
                }

                return sb.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }


}
/* LOGIC: In the above code we will split the word into different charectors, and then if the first charector is a vowel, 
 * then we will add "ma" after the last charector and then all of this is concatinated using the stringbuilder. Else if the word starts with 
 * a consonant then the first charector which is a consonant will be added in the last followed by "ma".





