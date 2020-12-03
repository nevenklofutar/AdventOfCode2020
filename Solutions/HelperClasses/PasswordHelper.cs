using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.HelperClasses {
    public class PasswordHelper {
        public int MinChars { get; set; }
        public int MaxChars { get; set; }
        public string Character { get; set; }
        public string Password { get; set; }

        public PasswordHelper(string line) {
            // example of one line: 1-3 a: abcde
            MinChars = int.Parse(line.Substring(0, line.IndexOf('-')));
            MaxChars = int.Parse(line.Substring(line.IndexOf('-') + 1, (line.IndexOf(' ')) - (line.IndexOf('-') + 1)));
            Character = line.Substring(line.IndexOf(':') - 1, 1);
            Password = line.Substring(line.LastIndexOf(' ') + 1);
        }

        public bool IsPasswordValidSled() {

            int counter = 0;
            foreach (var c in Password) {
                if (c.ToString() == Character)
                    counter++;
            }

            return (counter >= MinChars && counter <= MaxChars);
        }

        public bool IsPasswordValidToboggan() {

            int counter = 0;

            if (Password[MinChars - 1].ToString() == Character)
                counter++;
            if (Password[MaxChars - 1].ToString() == Character)
                counter++;

            return (counter == 1);
        }


    }

}
