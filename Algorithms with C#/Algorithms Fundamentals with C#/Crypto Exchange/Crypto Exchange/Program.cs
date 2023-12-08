namespace Crypto_Exchange
{
    internal class Program
    {
        static int FindMinimumTrades(Dictionary<string, List<string>> tradeRules, string source, string target)
        {
            Queue<(string, int)> queue = new Queue<(string, int)>();
            HashSet<string> visited = new HashSet<string>();

            queue.Enqueue((source, 0));

            while (queue.Count > 0)
            {
                var (asset, trades) = queue.Dequeue();

                if (asset == target)
                {
                    return trades;
                }

                if (!visited.Contains(asset))
                {
                    visited.Add(asset);

                    if (tradeRules.ContainsKey(asset))
                    {
                        foreach (var nextAsset in tradeRules[asset])
                        {
                            queue.Enqueue((nextAsset, trades + 1));
                        }
                    }
                }
            }

            return -1;
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> tradeRules = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string[] pair = Console.ReadLine().Split(" - ");
                string asset1 = pair[0];
                string asset2 = pair[1];

                if (!tradeRules.ContainsKey(asset1))
                {
                    tradeRules[asset1] = new List<string>();
                }

                if (!tradeRules.ContainsKey(asset2))
                {
                    tradeRules[asset2] = new List<string>();
                }

                tradeRules[asset1].Add(asset2);
                tradeRules[asset2].Add(asset1);
            }

            string[] request = Console.ReadLine().Split(" -> ");
            string sourceAsset = request[0];
            string targetAsset = request[1];

            int minimumTrades = FindMinimumTrades(tradeRules, sourceAsset, targetAsset);
            Console.WriteLine(minimumTrades);
        }
    }
}
 