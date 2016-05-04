//Alice is a kindergarden teacher. She wants to give some candies to the children in her class.  All the children sit in a line (their positions are fixed), and each  of them has
//a rating score according to his or her performance in the class.  Alice wants to give at least 1 candy to each child. If two children sit next to each other, then the one with the
//higher rating must get more candies. Alice wants to save money, so she needs to minimize the total number of candies given to the children.
//
//Input Format
//The first line of the input is an integer N, the number of children in Alice's class. Each of the following N lines contains an integer that indicates the rating of each child.
//1 <= N <= 10^5
//1 <= rating i <= 10^5
//
//Output Format
//Output a single line containing the minimum number of candies Alice must buy.
//
//Sample Input
//3  
//1  
//2  
//2
//
//Sample Output
//4
//
//Explanation
//Here 1, 2, 2 is the rating. Note that when two children have equal rating, they are allowed to have different number of candies. Hence optimal distribution will be 1, 2, 1.

using System;

class Solution
{
    public static void Main()
    {
        int children = int.Parse(Console.ReadLine());
        int[] ratings = new int[children];
        for (int i = 0; i < ratings.Length; i++)
        {
            ratings[i] = int.Parse(Console.ReadLine());
        }

        int[] candies = new int[children];

        for (int i = 1; i < candies.Length; i++)
        {
            if (ratings[i - 1] >= ratings[i])
            {
                candies[i] = candies[i - 1] - 1;
            }
            else
            {
                candies[i] = candies[i - 1] + 1;
            }
            if (candies[i] == 0)
            {
                increasePrevious(candies, i);
            }
        }

        int operationsDone;
        do
        {
            operationsDone = 0;
            for (int i = 0; i < candies.Length; i++)
            {
                if (candies[i] > 1)
                {
                    if (i == 0)
                    {
                        if (ratings[i + 1] >= ratings[i])
                        {
                            candies[i] = 1;
                            candies[i + 1] = 2;
                            operationsDone++;
                        }
                    }
                    else if (i == ratings.Length - 1)
                    {
                        if (ratings[i - 1] >= ratings[i])
                        {
                            candies[i] = 1;
                            candies[i - 1] = 2;
                            operationsDone++;
                        }
                    }
                    else if (ratings[i - 1] >= ratings[i])
                    {
                        if (ratings[i] <= ratings[i + 1])
                        {
                            candies[i] = 1;
                            candies[i - 1] = 2;
                            candies[i + 1] = 2;
                            operationsDone++;
                        }
                    }
                }
            }
        }
        while (operationsDone > 0);

        int sum = 0;
        foreach (int element in candies)
        {
            sum += element;
        }

        for (int i = 0; i < candies.Length; i++)
        {
            Console.WriteLine("{0} - {1}", ratings[i], candies[i]);
        }

        Console.WriteLine(sum);
        Console.ReadKey(true);
    }

    static void increasePrevious(int[] candies, int currentElement)
    {
        for (int i = 0; i <= currentElement; i++)
        {
            candies[i] += 1;
        }
    }
}