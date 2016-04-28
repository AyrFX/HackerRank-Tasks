//Given an array of integers, calculate which fraction of its elements are positive, which fraction of its elements are negative, and
//which fraction of its elements are zeroes, respectively.Print the decimal value of each fraction on a new line.

//Note: This challenge introduces precision problems.The test cases are scaled to six decimal places, though answers with absolute error
//of up to 10−410−4 are acceptable.

//Input Format
//The first line contains an integer, N, denoting the size of the array.
//The second line contains N space-separated integers describing an array of numbers (a0, a1, a2,…, an−1).

//Output Format
//You must print the following 3 lines:
//    A decimal representing of the fraction of positive numbers in the array.
//    A decimal representing of the fraction of negative numbers in the array.
//    A decimal representing of the fraction of zeroes in the array.

//Sample Input
//6
//-4 3 -9 0 4 1         

//Sample Output
//0.500000
//0.333333
//0.166667

//Explanation
//There are 3 positive numbers, 2 negative numbers, and 1 zero in the array.
//The respective fractions of positive numbers, negative numbers and zeroes are 36=0.500000, 26=0.333333 and 16=0.166667, respectively.


using System;

class Solution
{
    static void Main()
    {
        int arraySize = int.Parse(Console.ReadLine());
        string[] stringsArray = Console.ReadLine().Split(' ');
        int[] numbersArray = new int[arraySize];
        for (int i = 0; i < arraySize; i++)
        {
            numbersArray[i] = int.Parse(stringsArray[i]);
        }
        int positivesCount = 0, negativesCount = 0, zerosCount = 0;
        for (int i = 0; i < arraySize; i++)
        {
            if (numbersArray[i] > 0)
            {
                positivesCount++;
            }
            else if (numbersArray[i] < 0)
            {
                negativesCount++;
            }
            else
            {
                zerosCount++;
            }
        }
        Console.WriteLine("{0:F6}", positivesCount / (arraySize * 1.0));
        Console.WriteLine("{0:F6}", negativesCount / (arraySize * 1.0));
        Console.WriteLine("{0:F6}", zerosCount / (arraySize * 1.0));
    }
}