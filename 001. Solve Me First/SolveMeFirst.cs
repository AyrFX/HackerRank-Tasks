//Input Format
//Code that reads input from stdin is provided for you in the editor.There are 2 lines of input, and each line contains a single integer.

//Output Format
//Code that prints the sum calculated and returned by solveMeFirst is provided for you in the editor. 

using System;

class Solution
{
    static int solveMeFirst(int a, int b)
    {
        return a + b;
    }
    static void Main()
    {
        int val1 = Convert.ToInt32(Console.ReadLine());
        int val2 = Convert.ToInt32(Console.ReadLine());
        int sum = solveMeFirst(val1, val2);
        Console.WriteLine(sum);
    }
}