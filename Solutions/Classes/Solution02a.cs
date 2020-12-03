using Solutions.HelperClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Solutions.Classes {
    public class Solution02a {

        private readonly string _inputFilePath;

        public Solution02a(string inputFilePath) {
            _inputFilePath = inputFilePath;
        }

        public long GetSolution() {

            long result = 0;

            string[] data = GetData();
            List<PasswordHelper> list = GetPasswordHelpers(data);
            //result = GetValidPasswordCountPart1(list);
            result = GetValidPasswordCountPart2(list);

            return result;
        }

        private string[] GetData() {

            return File.ReadAllLines(Directory.GetCurrentDirectory() + "/Inputs/" + this._inputFilePath);
        }

        private List<PasswordHelper> GetPasswordHelpers(string[] input) {

            List<PasswordHelper> result = new List<PasswordHelper>();
            foreach (var line in input) {
                result.Add(new PasswordHelper(line));
            }
            return result;
        }

        private int GetValidPasswordCountPart1(List<PasswordHelper> list) {

            int result = 0;
            foreach (var pass in list) {
                if (pass.IsPasswordValidSled())
                    result++;
            }

            return result;
        }

        private int GetValidPasswordCountPart2(List<PasswordHelper> list) {

            int result = 0;
            foreach (var pass in list) {
                if (pass.IsPasswordValidToboggan())
                    result++;
            }

            return result;
        }


    }
}
