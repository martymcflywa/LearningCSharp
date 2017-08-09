using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqExercises
{
    static class Program
    {
        static void Main(string[] args)
        {
            //var elems = tRange(1, 10).tTake(20).ToArray();

            //var elems = tRange(1, 20).tWhere((number, index) => number -1 <= index).ToArray();

            int[] elems = { 0, 30, 20, 15, 90, 85, 40, 75 };

            var whereTest = elems.TWhere(number => number <= 10);
            var whereIndexTest = elems.TWhere((number, index) => number <= index * 10);

            foreach (var ele in whereTest)
                Console.WriteLine(ele);

            Console.ReadLine();
        }
    }
}
