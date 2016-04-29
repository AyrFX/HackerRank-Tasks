//Given an array A={a1,a2,…,aN} of N elements, find the maximum possible sum of a
// 1.Contiguous subarray
// 2.Non-contiguous (not necessarily contiguous) subarray.
//Empty subarrays/subsequences should not be considered.
//
//Input Format
//First line of the input has an integer T. T cases follow.
//Each test case begins with an integer N. In the next line, N integers follow representing the elements of array A.
//
//Constraints:
//1≤T≤10
//1≤N≤10^5
//−10^4≤ai≤10^4
//The subarray and subsequences you consider should have at least one element.
//
//Output Format
//Two, space separated, integers denoting the maximum contiguous and non-contiguous subarray. At least one integer should be selected and put into the subarrays (this may be required
//in cases where all elements are negative).
//
//Sample Input
//2 
//4 
//1 2 3 4
//6
//2 -1 2 3 4 -5
//
//Sample Output
//10 10
//10 11
//
//Explanation
//In the first case:
//The max sum for both contiguous and non-contiguous elements is the sum of ALL the elements (as they are all positive).
//
//In the second case:
//[2 -1 2 3 4] --> This forms the contiguous sub-array with the maximum sum.
//For the max sum of a not-necessarily-contiguous group of elements, simply add all the positive elements. 


using System;

class Solution
{
    public static void Main()
    {
        byte cases = byte.Parse(Console.ReadLine());
        string[,] sequences = new string[cases, 2];
        for (int i = 0; i < cases; i++)
        {
            sequences[i, 0] = Console.ReadLine();
            sequences[i, 1] = Console.ReadLine();
        }

        for (int i = 0; i < cases; i++)
        {
            int sequenceLength = int.Parse(sequences[i, 0]);
            string currentSequence = sequences[i, 1];
            int[] sequenceArray = Array.ConvertAll(currentSequence.Split(' '), Int32.Parse);
            long maxSum = long.MinValue, currentSum = 0, maxUnCSum = 0, maxArrayElement = long.MinValue;
            for (int j = 0; j < sequenceLength; j++)
            {
                if (j < 0)
                {
                    continue;
                }
                for (int k = j; k < sequenceLength; k++)
                {
                    for (int m = j; m <= k; m++)
                    {
                        if (currentSum + sequenceArray[m] <= 0 && m != j)
                        {
                            if (maxSum < currentSum)
                            {
                                maxSum = currentSum;
                            }
                            j = m;
                            k = m;
                            break;
                        }
                        currentSum += sequenceArray[m];
                    }
                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                    }
                    currentSum = 0;
                }

            }

            for (int j = 0; j < sequenceLength; j++)
            {
                if (sequenceArray[j] > 0)
                {
                    maxUnCSum += sequenceArray[j];
                }
                if (sequenceArray[j] > maxArrayElement)
                {
                    maxArrayElement = sequenceArray[j];
                }
            }

            if (maxSum <= 0)
            {
                Console.Write(maxArrayElement + " ");
            }
            else
            {
                Console.Write(maxSum + " ");
            }

            if (maxUnCSum <= 0)
            {
                Console.WriteLine(maxArrayElement);
            }
            else
            {
                Console.WriteLine(maxUnCSum);
            }
        }
    }
}