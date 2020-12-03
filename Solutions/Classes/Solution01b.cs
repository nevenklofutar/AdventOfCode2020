using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Solutions.Classes {
    public class Solution01b {
        private readonly string _filePath;

        public Solution01b(string filePath) {
            _filePath = filePath;
        }

        public long GetSolution() {

            long result = 0;

            int[] numbers = GetNumbers();

            for (int i = 0; i < numbers.Length - 2; i++) {
                for (int j = 1; j < numbers.Length - 1; j++) {
                    for (int k = 1; k < numbers.Length; k++) {
                        if (numbers[i] + numbers[j] + numbers[k] == 2020)
                            return numbers[i] * numbers[j] * numbers[k];
                    }
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
