using Solutions.HelperClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Solutions.Classes {
    public class Solution07 {

        private string goldBag = "shiny gold bag";

        public int GetSolutionOne(string filePath) {

            int result = 0;

            IList<string> data = GetDataOne(filePath);
            result = ProcessData(data);

            return result;
        }

        public int GetSolutionTwo(string filePath) {

            int result = 0;

            IList<string> data = GetDataOne(filePath);
            result = ProcessDataTwo(data);


            return result;
        }

        private IList<string> GetDataOne(string filePath) {

            return File.ReadAllLines(Directory.GetCurrentDirectory() + "/Inputs/" + filePath).ToList();
        }

        private int ProcessData(IList<string> data) {

            int result = 0;

            // key is bag name and value is list of bags that contain that bag
            Dictionary<string, List<string>> bags = new Dictionary<string, List<string>>();

            for (var i = data.Count - 1; i >= 0; i--) {

                string line = data[i];
                List<string> bagLineDataRaw = line.Split(" contain ").ToList();

                // if content of the bag is empty, delete this line
                if (bagLineDataRaw[1] == "no other bags.") {
                    data.RemoveAt(i);
                    continue;
                }

                string sourceBagName = bagLineDataRaw[0].Replace("bags", "bag");
                IList<string> destinationBagsRaw = bagLineDataRaw[1].Split(',').ToList();

                foreach (var contentBag in destinationBagsRaw) {

                    string bagInfo = contentBag.Trim().Replace(".", "").Replace("bags", "bag");

                    if (bagInfo == "no other bag")
                        continue;

                    int count = int.Parse(bagInfo.Substring(0, bagInfo.IndexOf(' ')));
                    string name = bagInfo.Substring(bagInfo.IndexOf(' ') + 1);

                    if (!bags.ContainsKey(name)) {
                        bags[name] = new List<string>();
                    }
                    if (!bags[name].Contains(sourceBagName)) {
                        bags[name].Add(sourceBagName);
                    }
                }
            }


            Bag golden = new Bag { Name = goldBag, Bags = new List<Bag>() };
            List<string> uniqueBagNamesList = new List<string>();
            FindSourceBagByName(bags, golden, uniqueBagNamesList);

            result = uniqueBagNamesList.Count;

            return result;
        }

        private int ProcessDataTwo(IList<string> data) {

            int result = 0;

            // key is bag name and value is list of bags that contain that bag
            Dictionary<string, List<BagExtended>> bags = new Dictionary<string, List<BagExtended>>();

            for (var i = data.Count - 1; i >= 0; i--) {

                string line = data[i];
                List<string> bagLineDataRaw = line.Split(" contain ").ToList();

                // if content of the bag is empty, delete this line
                if (bagLineDataRaw[1] == "no other bags.") {
                    data.RemoveAt(i);
                    continue;
                }

                string sourceBagName = bagLineDataRaw[0].Replace("bags", "bag");
                IList<string> destinationBagsRaw = bagLineDataRaw[1].Split(',').ToList();

                if (!bags.ContainsKey(sourceBagName))
                    bags[sourceBagName] = new List<BagExtended>();

                foreach (var contentBag in destinationBagsRaw) {

                    string bagInfo = contentBag.Trim().Replace(".", "").Replace("bags", "bag");

                    if (bagInfo == "no other bag")
                        continue;

                    int count = int.Parse(bagInfo.Substring(0, bagInfo.IndexOf(' ')));
                    string name = bagInfo.Substring(bagInfo.IndexOf(' ') + 1);

                    //if (!bags.ContainsKey(name)) {
                    //    bags[name] = new List<string>();
                    //}
                    //if (!bags[name].Contains(sourceBagName)) {
                    //    bags[name].Add(sourceBagName);
                    //}

                    bags[sourceBagName].Add(new BagExtended { Name = name, Count = count, Bags = new List<BagExtended>() });

                }
            }


            //Bag golden = new Bag { Name = goldBag, Bags = new List<Bag>() };
            //List<string> uniqueBagNamesList = new List<string>();
            //FindSourceBagByName(bags, golden, uniqueBagNamesList);

            //result = uniqueBagNamesList.Count;


            BagExtended initialBag = new BagExtended { Name = goldBag, Count = 1, Bags = new List<BagExtended>() };
            FindBagsByName(bags, initialBag);
            result = GetBagsCount(initialBag);

            return result;

        }

        private void FindBagsByName(Dictionary<string, List<BagExtended>> bags, BagExtended bag) {

            if (!bags.ContainsKey(bag.Name))
                return;

            List<BagExtended> contentBags = bags[bag.Name];
            bag.Bags = contentBags;
            
            foreach (var contentBag in bag.Bags) {
                FindBagsByName(bags, contentBag);
            }
        }

        private int GetBagsCount(BagExtended bag) {

            if (bag.Bags == null || bag.Bags.Count == 0)
                return 0;

            int tempCount = 0;
            foreach (var b in bag.Bags) {
                //int bagsCout = b.Count * GetBagsCount(b) + b.Count;
                //tempCount = tempCount + bagsCout;

                int bagsCount = b.Count * GetBagsCount(b);
                tempCount += b.Count + bagsCount;
            }

            return tempCount;
        }

        private void FindSourceBagByName(Dictionary<string, List<string>> bags, Bag sourceBag, List<string> uniqueBagNamesList) {
            if (!bags.ContainsKey(sourceBag.Name))
                return;

            var foundSources = bags[sourceBag.Name];

            foreach (var foundSource in foundSources) {
                Bag newBag = new Bag { Name = foundSource, Bags = new List<Bag>() };
                sourceBag.Bags.Add(newBag);

                if (!uniqueBagNamesList.Contains(foundSource))
                    uniqueBagNamesList.Add(foundSource);

                FindSourceBagByName(bags, newBag, uniqueBagNamesList);
            }
        }

        private class Bag {
            public string Name { get; set; }
            public List<Bag> Bags { get; set; }
        }

        private class BagExtended {

            public string Name { get; set; }
            public int Count { get; set; }

            public List<BagExtended> Bags { get; set; }

        }

    }
}
