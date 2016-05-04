//How many different ways can you make change for an amount, given a list of coins? In this problem, your code will
//need to efficiently compute the answer.

//Task
//Write a program that, given
//    The amount N to make change for and the number of types M of infinitely available coins
//    A list of M coins - C = {C1, C2, C3,.., CM}

//Prints out how many different ways you can make change from the coins to STDOUT.

//The problem can be formally stated:
//Given a value N, if we want to make change for N cents, and we have infinite supply of each of C = { C1, C2,…, CM }
//valued coins, how many ways can we make the change? The order of coins doesn’t matter.

//      Constraints    
//    1 ≤ Ci ≤ 50
//    1 ≤ N ≤ 250
//    1 ≤ M ≤ 50
//    The list of coins will contain distinct integers.

//Solving the overlapping subproblems using dynamic programming
//You can solve this problem recursively, but not all the tests will pass unless you optimise your solution to
//eliminate the overlapping subproblems using a dynamic programming solution
//Or more specifically;
//If you can think of a way to store the checked solutions, then this store can be used to avoid checking the same
//solution again and again.

//Input Format
//First line will contain 2 integer N and M respectively.
//Second line contain M integer that represent list of distinct coins that are available in infinite amount.

//Output Format
//One integer which is the number of ways in which we can get a sum of N from the given infinite supply of M types of coins.

//Sample Input
//4 3
//1 2 3 

//Sample Output
//4

//Sample Input #02
//10 4
//2 5 3 6

//Sample Output #02
//5

//Explanation
//    Example 1: For N = 4 and C = { 1, 2, 3 } there are four solutions: {1,1,1,1},{1,1,2},{2,2},{1,3}
//    Example 2: For N = 10 and C = { 2, 5, 3, 6 } there are five solutions: {2,2,2,2,2},{2,2,3,3},{2,2,6},{2,3,5},{5,5}

//Hints
//    Think about the degenerate cases:
//        How many ways can you give change for 0 cents?
//        How many ways can you give change for >0 cents, if you have no coins?
//    If you are having trouble defining your solutions store, then think about it in terms of the base case (n=0)
//    For help on reading from STDIN, see the HackerRank environment help page under the "Sample Problem Statement" section.


using System;

class Solution
{
    static void Main()
    {
        int[] inputParameters = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int amount = inputParameters[0];
        int typesNumber = inputParameters[1];
        int[] coinsValues = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);

        Array.Sort(coinsValues);
        Array.Reverse(coinsValues);

        Console.WriteLine(calculateWays(amount, coinsValues, coinsValues[0]));
    }

    static long calculateWays(long amount, int[] coinsValues, int currentCoinValue)
    {
        long numberOfWays = 0;
        int currentCoinIndex = Array.IndexOf(coinsValues, currentCoinValue);

        if (amount < currentCoinValue)
        {
            return 0;
        }
        if (amount == currentCoinValue)
        {
            return 1;
        }

        long maxOfType = amount / currentCoinValue;

        for (int i = 0; i <= maxOfType; i++)
        {
            if (currentCoinIndex + 1 > coinsValues.Length - 1)
            {
                if (amount % currentCoinValue == 0)
                {
                    numberOfWays = 1;
                }
                else
                {
                    numberOfWays = 0;
                }
            }
            for (int j = currentCoinIndex + 1; j <= coinsValues.Length - 1; j++)
            {
                numberOfWays += calculateWays(amount - currentCoinValue * i, coinsValues, coinsValues[j]);
            }
        }
        return numberOfWays;
    }
}