using Solutions.Classes;
using System;
using System.IO;

namespace Solutions {
    class Program {
        static void Main(string[] args) {


            //Solution01a s = new Solution01a("Input01b.txt");
            //Solution01b s = new Solution01b("Input01b.txt");

            //Solution02a s = new Solution02a("Input02b.txt");

            //Solution03 s = new Solution03();
            //long result = s.GetSolutionOne("Input03b.txt");

            //Solution04 s = new Solution04();
            //long result = s.GetSolutionOne("Input04a.txt");

            //Solution05 s = new Solution05();
            //int result = s.GetSolutionOne("Input05b.txt");
            //int result = s.GetSolutionTwo("Input05b.txt");

            Solution06 s = new Solution06();
            //int result = s.GetSolutionOne("Input06b.txt");
            int result = s.GetSolutionTwo("Input06b.txt");

            Console.WriteLine(result);

        }
    }
}
