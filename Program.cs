using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1_Summer2021
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1
            Console.WriteLine("Q1 : Enter the Moves of Robot:");
            string moves = Console.ReadLine();
            bool pos = JudgeCircle(moves);
            if (pos)
            {
                Console.WriteLine("The Robot return’s to initial Position (0,0)");
            }
            else
            {
                Console.WriteLine("The Robot doesn’t return to the Initial Postion (0,0)");
            }

            Console.WriteLine();

            //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s = Console.ReadLine();
            bool flag = CheckIfPangram(s);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();


            //Question 3:

            int[] arr = { 1, 2, 3, 1, 1, 3 };
            int gp = NumIdenticalPairs(arr);
            Console.WriteLine("Q3:");
            Console.WriteLine("The number of IdenticalPairs in the array are {0}:", gp);


            //Question 4:
            int[] arr1 = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4:");
            int pivot = PivotIndex(arr1);
            if (pivot > 0)
            {
                Console.WriteLine("The Pivot index for the given array is {0}", pivot);
            }
            else
            {
                Console.WriteLine("The given array has no Pivot index");
            }
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            Console.WriteLine("Enter the First Word:");
            String word1 = Console.ReadLine();
            Console.WriteLine("Enter the Second Word:");
            String word2 = Console.ReadLine();
            String merged = MergeAlternately(word1, word2);
            Console.WriteLine("The Merged Sentence fromed by both words is {0}", merged);


            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            string sentence = Console.ReadLine();
            string goatLatin = ToGoatLatin(sentence);
            Console.WriteLine("Goat Latin for the Given Sentence is {0}", goatLatin);
            Console.WriteLine();
            
        }

        /* 
<summary>
/// Input: moves = "UD"
/// Output: true
/// Explanation: The robot moves up once, and then down once. All moves have the same ///magnitude, so it ended up at the origin where it started. Therefore, we return true.
</summary>
<retunrs>true/False</returns>
*/
        private static bool JudgeCircle(string moves)
        {
            try
            {
                //First I set varibales x, y at starting positions (0,0) this is the initial coordinates.
                int x = 0;
                int y = 0;

                //Loop through the moves. I set 'i' as integer value and assigned it to start at value of 0.
                 for (int i = 0; i < moves.Length; i++) {

                    /*Used if statement to increment the count on whatever move we are on and assigned all move options 
                     that are available 'R' is right so will add 1 to x (x+1), 'L' is left so will subtract 1 from x (x-1),
                     'U' is up so will add 1 to y (y+1), and 'D' is down so will subtract 1 from y (y-1). 
                      
                    This part helps the computer indicate which direction the robot moved.  Also note, we have to account for both 
                    incrementing and decrementing since the robot can go both up (indicated by +) or down (indicated by -). */

                    if (moves[i] == 'R')
                        {
                            x = x +1;
                        }
                        else if (moves[i] == 'L')
                        {
                            x = x -1;
                        }
                        else if (moves[i] == 'U')
                        {
                            y = y +1;
                        }
                        else if (moves[i] == 'D')
                        {
                            y = y -1;
                        }
                  }

                /*If at end of moves both x and y ARE EQUAL to 0 values, than the robot has returned to its origin, so return value is true. 
                 However, if both x and y are NOT EQUAL to 0 at the end of the loop than than return false.*/

                if (x == 0 && y == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /* 
 <summary>
A pangram is a sentence where every letter of the English alphabet appears at least once.
Given a string sentence containing only lowercase English letters, return true if sentence is a pangram, or false otherwise.
Example 1:
Input: sentence = "thequickbrownfoxjumpsoverthelazydog"
Output: true
Explanation: sentence contains at least one of every letter of the English alphabet.
</summary>
</returns> true/false </returns>
Note: Use of String function (Contains) and hasmap is not allowed, think of other ways how you could the numbers be represented
        */


        private static bool CheckIfPangram(string s)
        {
            try
            {
                /*First created a character array (char is equal to 1 character). 
                  Since a pangram includes all of the English alphabets (a to z), I included all characters of the English alphabet within the array*/

                char[] arr = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
                    'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

                /*Assignd string data type to 'sent' variable. The sent variable is now the input string
                  Note that 's' (as per earlier the string 's' is the input variable). 
                  Convert string to lower case, since problem requires lower case letters to pass through for the input.*/

                string sent = s.ToLower();

                /*For loop to check if the pangram contains all the characters in the above array (arr)
                  The loop will iterate through the array starting at index 0 to search if the input includes all characters in the array*/

                for (int i = 0; i < arr.Length; i++)
                {
                    if (sent.Contains(arr[i]))
                        continue;
                    else
                        return false;
                }
            }

            catch (Exception)
            {

                throw;
            }

        }


        /*

 <summary> 
 Given an array of integers nums 
 A pair (i,j) is called good if nums[i] == nums[j] and i < j.
 Return the number of good pairs.
 Example:
 Input: nums = [1,2,3,1,1,3]
 Output: 4
 Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
   return type  : int
 </summary>
 <returns>int </returns>
     */

        private static int NumIdenticalPairs(int[] arr)
        {
            try
            {
                
                /* A formula that would work shown below (wrote it down in steps below);
                 * step 1: add sum of array of integers store in variable 'nums'
                 * step 2: obtain the total in 'nums' and subtract the left most integer (starting at index o and then incrementing by +1 in the array) to get total for the left of the index 
                 * step 3: obtain the value integer in that left most integer (i.e. if index 0 has 7 value than the sum of the left integer would be 7, if the index 1 has value of 1 then value would be 8 (7+1) 
                 * step 4: once the values in steps 2 & step 3 equal one another than the indexed value where this happens will be shown
                 */

                return 0;

            }
            catch (Exception)
            {

                throw;
            }
        }






        /*

          <summary>
   Given an array of integers nums, calculate the pivot index of this array.The pivot index is the index where the sum of all the numbers strictly to the left of  the index is equal to the sum of all the numbers strictly to the index's right.
  If the index is on the left edge of the array, then the left sum is 0 because there are no elements to the left. This also applies to the right edge of the array.
  Return the leftmost pivot index. If no such index exists, return -1.
  Example 1:
  Input: nums = [1,7,3,6,5,6]
         Output : 3


      Explanation:
  The pivot index is 3.
  Left sum = nums[0] + nums[1] + nums[2] = 1 + 7 + 3 = 11
  Right sum = nums[4] + nums[5] = 5 + 6 = 11
          /// </summary>
          /// <param name="nums"></param>
          /// <returns>Number the index in the array</returns>
      */
                private static int PivotIndex(int[] nums)
        {
            try
            {
                
                //Create varibale 'len' which will count the number of good pairs in the nums array.
                {
                    int len = nums.Length;

                    //Initialize count to 0. This count will count good pairs.
                    int count = 0;

                    /*use a for loop to loop through the array. There are 2 variables i & j so there will be 2 separate for loops to loop through 
                      the *array twice. The second for loop is a nested loop that is nested within the first loop.*/

                    for (int i = 0; i < len; i++)
                    {
                        //Since the second condition requires i < j, we have j set to equal i.
                        //While j is less than the legnth, increment j by adding 1. Therefore, the second condition of i < j is met.

                        for (int j = i; j < len; j++)
                        {
                            //Check if nums that are indexed in i is equal to nums that are indexed in j AND also i not equal to jj.
                            //If both conditions are true, increase count by adding 1.
                            if (nums[i] == nums[j] && i != j)
                            {
                                count++;
                            }
                        }
                    }

                    //return the result, the count variable when the loop is done
                    return count;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

                            }

                            /*
                                /// <summary>
                        /// You are given two strings word1 and word2. Merge the strings by adding letters /// in alternating order, starting with word1. If a string is longer than the other,
                        /// append the additional letters onto the end of the merged string.
                        /// Example 1
                        /// Input: word1 = "abc", word2 = "pqr"
                        /// Output: "apbqcr"
                        /// Explanation: The merged string will be merged as so:
                        /// word1:  a   b   c
                        /// word2:    p   q   r
                        /// merged: a p b q c r
                        /// </summary>
                               /// <param name="word1"></param>
                        ///<param name="word2"></param>
                               /// <returns>return the merged string </returns>

                        */

                    private static string 
            MergeAlternately(string word1, string word2)
        {
            try
            {
                
                /*The answer should meet two objectives, the first is if words in 2 separate strings (word 1 & word 2) are equal in length 
                  then alternate the characters **Starting with word 1**.  

                  The second objective is if any remaining characters (i.e. if word 1 and word 2 are not equal in length then append the 
                  remaining letters at the end of the string.

                  First I made a list of characters because I want to use list of characters since each word will be looped through
                  one character at a time, I used a List<char>*/

                List<char> ans = new List<char>();

                //Created two variables (since we will have 2 words). Set both variables as integer with starting value as 0.
                int a = 0;
                int b = 0;

                /*Used a while loop to iterate through word1 and word2 using a conditional'or' denoted as '||' operator.
                  Pass each word through the loop, iterating with the length of the shorter word because if the strings don't match in length 
                  we can append the remaining characters of the word */

                while (a < word1.Length || b < word2.Length)
                {
                    //Appending both of the characters starting with word1 and then word2 while incrementing each time so we can get to the next character.
                    if (a < word1.Length)
                    {
                        ans.Add(word1[a]);
                        a++;
                    }

                    if (b < word2.Length)
                    {
                        ans.Add(word2[b]);
                        b++;
                    }

                    //Join the characters as a string and return the result.
                    return string.Join(string.Empty, ans);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        /*
        <summary>
        /// A sentence sentence is given, composed of words separated by spaces. Each word consists of lowercase and uppercase letters only.
        We would like to convert the sentence to "Goat Latin" (a made-up language similar to Pig Latin.)
        The rules of Goat Latin are as follows:
        1)	If a word begins with a vowel (a, e, i, o, or u), append "ma" to the end of the word.
         For example, the word 'apple' becomes 'applema'.

        2)	If a word begins with a consonant (i.e. not a vowel), remove the first letter and append it to the end, then add "ma".
        For example, the word "goat" becomes "oatgma".

        3)	Add one letter 'a' to the end of each word per its word index in the sentence, starting with 1.
        For example, the first word gets "a" added to the end, the second word gets "aa" added to the end and so on.
        Hint : think of a string function to divide the sentence on white spaces
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns> string</returns>
       */
        private static string ToGoatLatin(string sentence)
        {
            try
            {
                //First used HashSet() constructor to convert character array of vowels into a set           
                ISet<char> vowels = new HashSet<char>() { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u' };

                /*Used a string split method which returns a string array that contains the substrings. 
                  In this instance that are deliminted by elements of a character array.

                  Note: Split is used to break a delimited string into substrings.You can use either a character array 
                  or a string array to specify zero or more delimiting characters or strings.If no delimiting characters are specified, 
                  the string is split at white - space characters.*/
                

                var builders = string.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEnteries).Select(w => new StringBuilder(w)).ToArray();

                //Set endCount variable as integer value of 1
                int endCount = 1;

                //Used a builder pattern in a for loop
                foreach (var builder in builders)
                {
                    //Started with first condition if met, if vowel is at index 0 (aka the first letter of sentence), then append 'ma' to end of that word.
                    if (vowels.Contains(builders[0]))
                    {
                        builder.Append("ma");
                    }

                    //Next if first condition is not met (see above), than remove characters at index 0 & 1 and append it to the end than add 'ma'
                    else
                    {
                        var first = builder[0];
                        builder.Remove(0, 1);
                        builder.Append(first);
                        builder.Append("ma");
                    }

                    //Finally iterate through each word by adding character 'a' to the end, and increment character by adding one for each word. 
                    builder.Append('a', endCount + 1);

                }

                //Join the characters to form a complete word in a string data type.
                return string.Join(" ", builders.Select(builders => builders.ToString().ToArray()));

            }
            catch (Exception)
            {

                throw;
            }


        }


    }
}

