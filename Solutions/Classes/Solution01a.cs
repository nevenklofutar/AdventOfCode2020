using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Solutions.Classes {
    public class Solution01a {
        private readonly string _filePath;

        public Solution01a(string filePath) {
            _filePath = filePath;
        }

        public long GetSolution() {

            long result = 0;

            int[] numbers = GetNumbers();

            for (int i = 0; i < numbers.Length - 1; i++) {
                for (int j = 1; j < numbers.Length; j++) {
                    if (numbers[i] + numbers[j] == 2020)
                        return numbers[i] * numbers[j];
                }
            }

            return result;
        }

        private int[] GetNumbers() {

            string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "/Inputs/" + this._filePath);
            return Array.ConvertAll<string, int>(lines, line => int.Parse(line));
        }

    }
}
