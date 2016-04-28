//Your teacher has given you the task of drawing a staircase structure. Being an expert programmer, you decided to make a program to draw it for you instead. Given the required height,
//can you print a staircase as shown in the example?
//
//Input
//You are given an integer N depicting the height of the staircase.
//
//Output
//Print a staircase of height N that consists of # symbols and spaces. For example for N=6, here's a staircase of that height:
//
//     #
//    ##
//   ###
//  ####
// #####
//######
//
//Note: The last line has 0 spaces before it. 

using System;

class Solution
{
    public static void Main()
    {
        int height = int.Parse(Console.ReadLine());

        for (int i = 1; i <= height; i++)
        {
            Console.Write(new string(' ', height - i));
            Console.Write(new string('#', i));
            Console.WriteLine();
        }
    }
}