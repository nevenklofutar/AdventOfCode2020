using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Solutions.Classes {
    
    public class Solution06 {

        public int GetSolutionOne(string filePath) {

            int result = 0;

            IList<string> data = GetDataOne(filePath);
            result = GetResultOne(data);

            return result;
        }

        private IList<string> GetDataOne(string filePath) {

            IEnumerable<string> data = File.ReadAllLines(Directory.GetCurrentDirectory() + "/Inputs/" + filePath);
            IList<string> allAnswers = new List<string>();

            string groupAnswers = string.Empty;
            int emptylines = 0;

            foreach (var line in data) {
                string newline = line.ToLower();
                if (string.IsNullOrEmpty(newline)) {
                    allAnswers.Add(groupAnswers);
                    groupAnswers = string.Empty;
                    emptylines++;
                    continue;
                }

                // parse single line for data
                groupAnswers = string.Concat(groupAnswers, newline);
            }

            // add last line
            allAnswers.Add(groupAnswers);

            return allAnswers;
        }

        private int GetResultOne(IList<string> data) {

            IList<char> tempCounter = new List<char>();
            int result = 0;

            foreach (var group in data) {
                foreach (var character in group) {
                    if (!tempCounter.Contains(character))
                        tempCounter.Add(character);
                }

                result += tempCounter.Count;
                tempCounter = new List<char>();
            }

            return result;
        }

    }
}
