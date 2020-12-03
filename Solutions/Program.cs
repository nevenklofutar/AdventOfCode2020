using Solutions.Classes;
using System;
using System.IO;

namespace Solutions {
    class Program {
        static void Main(string[] args) {


            //Solution01a s = new Solution01a("Input01b.txt");
            //Solution01b s = new Solution01b("Input01b.txt");

            //Solution02a s = new Solution02a("Input02b.txt");

            Solution03 s = new Solution03();
            //long result = s.GetSolutionOne("Input03b.txt");
            long result = s.GetSolutionTwo("Input03b.txt");

            Console.WriteLine(result);

        }
    }
}
