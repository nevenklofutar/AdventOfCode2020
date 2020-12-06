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

        public int GetSolutionTwo(string filePath) {

            int result = 0;

            IEnumerable<string> data = GetDataTwo(filePath);
            result = GetResultTwo(data);

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

        private IEnumerable<string> GetDataTwo(string filePath) {

            return File.ReadAllLines(Directory.GetCurrentDirectory() + "/Inputs/" + filePath);
        }

        private int GetResultTwo(IEnumerable<string> data) {

            // for each group get first answer, and then check if all others have
            // aswers that match first person answers

            int result = 0;
            Dictionary<char, int> firstPersonAnswers = null;
            int groupPersonsCount = 1;

            foreach (var answers in data) {

                if (string.IsNullOrEmpty(answers)) {
                    // for current group, calculate answers
                    result += CalculateGroupAnswers(groupPersonsCount, firstPersonAnswers);
                    // reset group on empty line
                    firstPersonAnswers = null;
                    groupPersonsCount = 1;
                    continue;
                }

                // if new group, get first persons answers as a reference
                if (firstPersonAnswers == null) {
                    firstPersonAnswers = new Dictionary<char, int>();

                    foreach (var answer in answers) {
                        firstPersonAnswers[answer] = 1;
                    }

                    continue;
                }

                // calculat subsequent persons from the same group according to the first person in the group
                groupPersonsCount++;
                foreach (var answer in answers) {
                    if (firstPersonAnswers.ContainsKey(answer))
                        firstPersonAnswers[answer] += 1;
                }

            }

            // for last group, calculate answers
            result += CalculateGroupAnswers(groupPersonsCount, firstPersonAnswers);

            return result;
        }

        private int CalculateGroupAnswers(int groupPersonsCount, Dictionary<char, int> firstPersonAnswers) {

            int result = 0;

            foreach (var answer in firstPersonAnswers.Keys) {
                if (firstPersonAnswers[answer] == groupPersonsCount)
                    result++;
            }

            return result;
        }
    }
}
