using System;
using System.Collections.Generic;
using System.Linq;

namespace Backtracking.Algorithm;

public static class Program
{
    private const int DefaultLimit = 10;

    public static void Main()
    {
        string keepGoing = "yes";
        while (keepGoing.Equals("yes", StringComparison.InvariantCultureIgnoreCase))
        {
            try
            {
                Console.WriteLine("Please write your letters/words with space in between(e.g. a b c)");
                var items = Console.ReadLine();
                var parsedItems = items?.Split(" ");

                if (parsedItems?.Length is 0 or null)
                    throw new Exception("no letters/words for concatenation were provided");


                Console.WriteLine("Please write you character limit per one item(empty input will result in default limit of 10)");
                var limit = Console.ReadLine();

                long finalLimit = DefaultLimit;

                if (!string.IsNullOrWhiteSpace(limit))
                {
                    if (!long.TryParse(limit, out long parsedLimit))
                        throw new Exception($"limit has to be lower than {long.MaxValue}");

                    if (parsedLimit <= 0)
                        throw new Exception("limit has to be more than 0");

                    finalLimit = parsedLimit;
                }

                if (finalLimit > parsedItems.Length)
                    throw new Exception("limit has to be less or equal to the amount of letters/words");

                var results = new List<string>();
                Backtrack(parsedItems.Take(parsedItems.Length).ToList(), results, finalLimit);

                Console.WriteLine($"RESULTS: {string.Join("--", results)}");
                Console.WriteLine($"{results.Count} results were generated");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Do you want to keep going? (yes/no)");

            keepGoing = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(keepGoing))
            {
                break;
            }
        }
    }

    private static void Backtrack(List<string> items, List<string> results, long limit, string result = "")
    {
        if (result.Length >= limit)
        {
            results.Add(result);
            return;
        }

        for (var x = 0; x < items.Count; x++)
        {
            var newItems = new List<string>();
            for (var y = 0; y < items.Count; y++)
            {
                if (x != y)
                    newItems.Add(items[y]);
            }

            var newResult = result + items[x];
            Backtrack(newItems, results, limit, newResult);
        }
    }
}