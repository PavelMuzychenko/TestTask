using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tribonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            (int n, int k) = FetchInput();
            ulong[] result = GetPart(n, k);

            foreach (var item in result)
            {
                Console.Write(item + " ");
            }

            Console.ReadKey();
        }

        static (int, int) FetchInput()
        {
            int n, k;

            do
            {
                Console.WriteLine("Enter N:");
                bool flag = int.TryParse(Console.ReadLine(), out n);
                if (!flag)
                {
                    Console.WriteLine("N must be an integer");
                    continue;
                }
                if (n < 1)
                {
                    Console.WriteLine("N must be greater than 0");
                    continue;
                }

                Console.WriteLine("Enter K:");
                flag = int.TryParse(Console.ReadLine(), out k);
                if (!flag)
                {
                    Console.WriteLine("K must be an integer");
                    continue;
                }
                if (k < 2)
                {
                    Console.WriteLine("K must be greater than 1");
                    continue;
                }

                if (k <= n)
                {
                    Console.WriteLine("K must be greater than N");
                    continue;
                }

                break;

            } while (true);

            return (n, k);
        }

        static ulong[] GetPart(int n, int k)
        {
            List<ulong> numbers = new List<ulong>();
            Dictionary<int, ulong> cache = new Dictionary<int, ulong>();
            for (int i = n; i <= k; i++)
            {
                numbers.Add(Tribonacci(i));
            }

            ulong Tribonacci(int x)
            {
                if (cache.TryGetValue(x, out ulong result))
                    return result;

                result = x > 3 ? Tribonacci(x - 1) + Tribonacci(x - 2) + Tribonacci(x - 3) : 1;
                cache[x] = result;
                return result;
            }

            return numbers.ToArray();
        }
    }
}
