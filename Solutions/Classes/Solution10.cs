using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Solutions.Classes {
    public class Solution10 {

        List<string> paths = new List<string>();

        public int GetSolutionOne(string filePath) {

            List<string> data = GetData(filePath);
            List<int> numbers = GetNumbersData(data);
            numbers.Sort();

            int adapterOneCount = 0;
            int adapterThreeCount = 0;
            int value = 0;
            bool foundTarget = true;

            while (foundTarget) {

                foundTarget = false;

                // find next valid adapter in the 1 - 3 range
                for (int index = 1; index <= 3; index++) {
                    int numberToFind = value + index;

                    if (numbers.Contains(numberToFind)) {

                        value += index;

                        if (index == 1)
                            adapterOneCount++;
                        if (index == 3)
                            adapterThreeCount++;

                        foundTarget = true;
                    }

                    if (foundTarget)
                        break;
                }
            }

            adapterThreeCount++;

            return adapterOneCount * adapterThreeCount;
        }

        public long GetSolutionTwo(string filePath) {

            List<string> data = GetData(filePath);
            List<int> numbers = GetNumbersData(data);
            numbers.Sort();
            int maxValue = numbers.Max();
            long totalCount = 0;
            string path = string.Empty;

            CalculateTwo(0, ref totalCount, maxValue, path, numbers);

            return totalCount;
        }

        public long GetSolutionThree(string filePath) {

            List<string> data = GetData(filePath);
            List<int> numbers = GetNumbersData(data);
            numbers.Sort();

            Console.WriteLine(numbers.ToArray().ToString());

            return 0;
        }

        private List<string> GetData(string filePath) {
            return File.ReadAllLines(Directory.GetCurrentDirectory() + "/Inputs/" + filePath).ToList();
        }

        private List<int> GetNumbersData(IList<string> data) {

            List<int> numbers = new List<int>();

            foreach (var line in data)
                numbers.Add(int.Parse(line));

            return numbers;
        }

        private void CalculateTwo(int currentValue, ref long totalCount, int maxValue, string path, List<int> numbers) {

            //path += ";" + currentValue;

            if (currentValue == maxValue) {
                //paths.Add(path);
                totalCount++;
                return;
            }

            if (!numbers.Contains(currentValue) && currentValue > 0)
                return;

            for (int i = 1; i <= 3; i++) {
                CalculateTwo(currentValue + i, ref totalCount, maxValue, path, numbers);
            }
        }

    }
}
