using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lowest_common_denominator2
{
    class Program
    {
        static List<int> input() {
            List<int> res = new List<int>();
            Console.WriteLine("Enter numbers -1 to finish");
            while(true){
                Console.Write("Enter number ");
                int number=int.Parse(Console.ReadLine());
                if (number == -1)
                    break;
                res.Add(number);
            }
            return res;
        }
        static int next_prime(int prime) {
            int div = 2;
            prime++;
            while (div <= prime / 2) {
                if (prime % div == 0){
                    prime++;
                    div = 2;
                }
                div++;
            }
            return prime;
        }
        static void lowestCommonDenominator(List<int>numbers) {
            int res = 1;
            int prime = 2;
            int lcm = 1;
            List<int>primes=new List<int>();
            bool isAllOne = false;
            Console.WriteLine();
            print(numbers);
            while (isAllOne == false) {
                int countOne = 0;
                bool isDivided = false;
                for (int i = 0; i < numbers.Count; i++){
                    if (numbers[i] % prime == 0){
                        isDivided = true;
                        numbers[i] /= prime;
                    }
                    if (numbers[i] == 1)
                        countOne++;
                }
                if (isDivided)
                    primes.Add(prime);
                else
                    prime = next_prime(prime);
                if (countOne == numbers.Count)
                    isAllOne = true;
            }
            foreach (int i in primes)
                lcm *= i;
            Console.WriteLine("Lowest common denominator is = " + lcm);
        }
        static void print(List<int> numbers) {
            string res="[";
            for (int i = 0; i < numbers.Count - 1; i++)
                res += numbers[i] + ",";
            if (numbers.Count > 0)
                res += numbers[numbers.Count - 1] + "]";
            Console.WriteLine("numbers = " + res);
        }
        static void Main(string[] args)
        {
            lowestCommonDenominator(input());
            Console.ReadLine();
        }
    }
}
