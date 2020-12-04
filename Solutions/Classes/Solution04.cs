using Solutions.HelperClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Solutions.Classes {
    public class Solution04 {

        public int GetSolutionOne(string filePath) {
            int result = 0;

            IEnumerable<Passport> passports = GetData(filePath);

            foreach (var passport in passports) {
                if (passport.IsPasswordValidOne())
                    result++;
            }

            return result;
        }

        public int GetSolutionTwo(string filePath) {
            int result = 0;

            IEnumerable<Passport> passports = GetData(filePath);

            foreach (var passport in passports) {
                try {
                    if (passport.IsPasswordValidTwo())
                        result++;
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }

        private IEnumerable<Passport> GetData(string filePath) {

            IEnumerable<string> data = File.ReadAllLines(Directory.GetCurrentDirectory() + "/Inputs/" + filePath);
            IList<Passport> passports = new List<Passport>();
            Passport passport = new Passport();
            int emptylines = 0;

            foreach (var line in data) {
                string newline = line.ToLower();
                if (string.IsNullOrEmpty(newline)) {
                    passports.Add(passport);
                    passport = new Passport();
                    emptylines++;
                    continue;
                }

                // parse single line for data
                string[] properties = newline.Split(' ');
                foreach (var property in properties) {
                    string[] keyvaluepairs = property.Split(':');
                    passport.SetProperty(keyvaluepairs);
                }
            }

            // add last passport to the list
            passports.Add(passport);

            return passports;
        }

    }
}
