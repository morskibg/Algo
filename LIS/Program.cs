using System;
using System.Collections.Generic;
using System.Linq;

namespace LIS
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] lisLength = new int[nums.Length];
            int[] prevIndex = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                lisLength[i] = 1;
                prevIndex[i] = -1;
                for (int j = 0; j < i; j++)
                {
                    
                    if(nums[j] < nums[i] && lisLength[j] >= lisLength[i])
                    {
                        ++lisLength[i];
                        prevIndex[i] = j;
                    }
                }
            }
            int maxLisLen = lisLength.OrderBy(x => -x).First();
            int maxIdx = lisLength.TakeWhile(x => x < maxLisLen).Count();
            int[] LIS = new int[maxLisLen];
            for (int i = maxLisLen - 1; i >= 0; i--)
            {
                LIS[i] = nums[maxIdx];
                maxIdx = prevIndex[maxIdx];
            }
            Console.WriteLine(string.Join(" ", LIS));
            ;
        }
    }
}
