using System;
using System.Collections.Generic;
using System.Linq;

//8 3 5 7 0 8 9 10 20 20 20 12 19 11
namespace ZigZag
{
    class Program
    {
        private static int[] nums;
        private static int[] length;
        private static int[] prev;
        private static int lastNum;
        static void Main(string[] args)
        {
            nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            length = new int[nums.Length];
            prev = new int[nums.Length];
            CalclLongestZigZag();
            List<int> result = new List<int>();
            var maxLen = length.Max();
            var maxIdx = Array.IndexOf(length, maxLen);
            result.Add(nums[maxIdx]);
            int idx = prev[prev.Length - 1];
            while (idx != -1)
            {
                result.Add(nums[idx]);
                idx = prev[idx];
            }
            result.Reverse();
            Console.WriteLine(string.Join(" ",result));
            ;
        }

        private static void CalclLongestZigZag()
        {
            int lastNum = 1;
            int prevIdx = -1;
            
            for (int i = 0; i < nums.Length; i++)
            {
                length[i] = 1;
                prev[i] = -1;
                for (int j = 0; j < i; j++)
                {
                    if (length[j] >= length[i] && j == 0)
                    {
                        length[i] = length[j] + 1;
                        prev[i] = j;
                    } 
                    else if (nums[prev[j]] > nums[j] && nums[j] < nums[i] && length[j] >= length[i] )
                    {
                        length[i] = length[j] + 1;
                        prev[i] = j;
                    }
                    else if (nums[prev[j]] < nums[j] && nums[j] > nums[i] && length[j] >= length[i])
                    {
                        length[i] = length[j] + 1;
                        prev[i] = j;
                    }
                }
            }
        }
    }
}
