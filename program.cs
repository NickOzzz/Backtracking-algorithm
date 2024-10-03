using System;
using System.Collections.Generic;
using System.Linq;

namespace Backtracking.Algorithm
{
    class Program
    {
        private static readonly List<int> result = new();

        public static int Main()
        {
            string finish = "No";
            while (finish.ToLower() != "yes") 
            {
                Console.Write("Range to pick numbers from: ");
                var rangeForNumbers = Console.ReadLine();

                Console.Write("Amount of additions: ");
                var amountOfAdditions = Console.ReadLine();

                Console.Write("Enter target: ");
                var targetToReach = Console.ReadLine();

                var countOfResults = NumRollsToTarget(Int32.Parse(amountOfAdditions), Int32.Parse(rangeForNumbers), Int32.Parse(targetToReach));

                Console.WriteLine("-----------------------");
                Console.WriteLine($"Amount of possible combinations: {countOfResults}");
                Console.WriteLine("-----------------------");

                Console.Write("Finish execution? yes/no : ");
                finish = Console.ReadLine();
                Console.WriteLine("-----------------------");
            }

            return 0;
        }

        public static int NumRollsToTarget(int n, int k, int target)
        {
            Backtrack(0, n, k, target);
            return result.Count;
        }

        private static void Backtrack(int sum, int n, int k, int target)
        {
            if (sum == target && n == 0)
            {
                result.Add(sum);
                return;
            }
            if (sum >= target || n == 0)
            {
                return;
            }
            foreach (var item in Enumerable.Range(1, k))
            {
                Backtrack(sum + item, n - 1, k, target);
            }
        }
    }
}