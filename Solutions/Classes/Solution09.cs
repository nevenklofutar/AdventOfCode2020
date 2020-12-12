using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Solutions.Classes {
    public class Solution09 {

        public long GetSolutionOne(string filePath) {

            int result = 0;

            IList<string> data = GetData(filePath);
            IList<long> numbers = GetListOfNumbers(data);

            int size = 25;
            int endIndex = size - 1;

            for (int index = endIndex + 1; index < numbers.Count; index++) {

                int currentStart = index - size;
                int currentEnd = currentStart + size - 1;
                bool foundSum = false;

                for (int i = currentStart; i < currentEnd; i++) {
                    for (int j = i + 1; j <= currentEnd; j++) {
                        if (numbers[index] == numbers[i] + numbers[j]) {
                            foundSum = true;
                            break;
                        }
                    }
                }

                if (foundSum == false)
                    return numbers[index];
            }

            return result;
        }

        public long GetSolutionTwo(string filePath, int target) {

            int result = 0;

            IList<string> data = GetData(filePath);
            IList<long> numbers = GetListOfNumbers(data);
            
            int targetIndex = numbers.IndexOf(target);

            for (int i = 0; i < targetIndex - 1; i++) {

                long sum = numbers[i];
                long min = numbers[i];
                long max = numbers[i];

                for (int j = i + 1; j < targetIndex; j++) {
                    sum += numbers[j];

                    if (numbers[j] < min)
                        min = numbers[j];
                    if (numbers[j] > max)
                        max = numbers[j];

                    if (sum == target)
                        return min + max;
                }
            }

            return result;
        }

        private IList<string> GetData(string filePath) {
            return File.ReadAllLines(Directory.GetCurrentDirectory() + "/Inputs/" + filePath);
        }

        private List<long> GetListOfNumbers(IList<string> data) {
            List<long> list = new List<long>();

            foreach (var number in data)
                list.Add(long.Parse(number));

            return list;
        }
    }
}
