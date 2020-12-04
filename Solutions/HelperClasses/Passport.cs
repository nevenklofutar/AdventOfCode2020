using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Solutions.HelperClasses {
    public class Passport {

        public string byr { get; set; }
        public string iyr { get; set; }
        public string eyr { get; set; }
        public string hgt { get; set; }
        public string hcl { get; set; }
        public string ecl { get; set; }
        public string pid { get; set; }
        public string cid { get; set; }

        public bool IsPasswordValidOne() {

            if (string.IsNullOrEmpty(byr) || string.IsNullOrEmpty(iyr) || string.IsNullOrEmpty(eyr) || string.IsNullOrEmpty(hgt)
                || string.IsNullOrEmpty(hcl) || string.IsNullOrEmpty(ecl) || string.IsNullOrEmpty(pid))
                return false;

            return true;
        }

        public bool IsPasswordValidTwo() {

            if (string.IsNullOrEmpty(byr) || string.IsNullOrEmpty(iyr) || string.IsNullOrEmpty(eyr) || string.IsNullOrEmpty(hgt)
                || string.IsNullOrEmpty(hcl) || string.IsNullOrEmpty(ecl) || string.IsNullOrEmpty(pid))
                throw new Exception("fali propert");

            // byr
            if (byr.Length != 4)
                throw new Exception("byr ne 4");
            int ibyr = 0;
            int.TryParse(byr, out ibyr);
            if (ibyr < 1920 || ibyr > 2002)
                throw new Exception("byr value");

            // iyr
            if (iyr.Length != 4)
                throw new Exception("iyr ne 4");
            int iiyr = 0;
            int.TryParse(iyr, out iiyr);
            if (iiyr < 2010 || iiyr > 2020)
                throw new Exception("iyr value");

            // eyr
            if (eyr.Length != 4)
                throw new Exception("eyr ne 4");
            int ieyr = 0;
            int.TryParse(eyr, out ieyr);
            if (ieyr < 2020 || ieyr > 2030)
                throw new Exception("eyr value");

            // hgt
            if (hgt.Length < 4 || hgt.Length > 5)
                throw new Exception("hgt ne 4, 5");
            string unit = hgt.Substring(hgt.Length - 2);
            if (unit != "in" && unit != "cm")
                throw new Exception("hgt units");
            string stringsize = hgt.Substring(0, hgt.Length - 2);
            int size = 0;
            int.TryParse(stringsize, out size);
            if (unit == "in")
                if (size < 59 || size > 76)
                    throw new Exception("hgt in size");
            if (unit == "cm")
                if (size < 150 || size > 193)
                    throw new Exception("hgt cm size");

            // hcl
            if (hcl.Length != 7)
                throw new Exception("hcl ne 7");
            if (hcl.Substring(0, 1) != "#")
                throw new Exception("hcl #");
            List<string> hclvalidchars = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "a", "b", "c", "d", "e", "f" };
            string hclvalue = hcl.Substring(1, 6);
            foreach (var character in hclvalue) {
                if (!hclvalidchars.Contains(character.ToString()))
                    throw new Exception("hcl value");
            }

            // ecl
            if (ecl.Length != 3)
                throw new Exception("ecl ne 3");
            List<string> eclvalidvalues = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            if (!eclvalidvalues.Contains(ecl))
                throw new Exception("ecl value");

            // pid
            if (pid.Length != 9)
                throw new Exception("pid ne 9");
            List<string> pidvalidchars = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            foreach (var c in pid) {
                if (!pidvalidchars.Contains(c.ToString()))
                    throw new Exception("pid value");
            }

            return true;
        }

        public void SetProperty(string[] keyvaluepair) {

            Type myType = typeof(Passport);
            PropertyInfo myPropInfo = myType.GetProperty(keyvaluepair[0]);
            myPropInfo.SetValue(this, keyvaluepair[1], null);

        }
    }
}
