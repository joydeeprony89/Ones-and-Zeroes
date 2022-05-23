using System;

namespace Ones_and_Zeroes
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
  }
  // https://www.youtube.com/watch?v=qkUZ87NCYSw
  // https://leetcode.com/problems/ones-and-zeroes/
  public class Solution
  {
    public int FindMaxForm(string[] strs, int m, int n)
    {
      int[,,] dp = new int[strs.Length, m + 1, n + 1];
      return Helper(strs, m, n, 0, dp);
    }

    private int Helper(string[] strs, int m, int n, int index, int[,,] dp)
    {
      // Recursion breaking condition
      if (index == strs.Length || m + n == 0) return 0;

      if (dp[index, m, n] > 0) return dp[index, m, n];

      string s = strs[index];
      var counts = Count(s);
      int zero = counts[0];
      int one = counts[1];

      int consider = 0;
      if (m >= zero && n >= one)
      {
        consider = 1 + Helper(strs, m - zero, n - one, index + 1, dp);
      }

      // if we do not cosider current string
      int notConsider = Helper(strs, m, n, index + 1, dp);

      int finalMax = Math.Max(consider, notConsider);
      dp[index, m, n] = finalMax;
      return finalMax;
    }

    private int[] Count(string s)
    {
      int[] count = new int[2];
      foreach (char c in s)
      {
        count[c - '0']++;
      }

      return count;
    }
  }

}
