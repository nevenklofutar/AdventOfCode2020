using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Solutions.Classes {
    public class Solution03 {

        private const string tree = "#";

        public int GetSolutionOne(string filePath) {

            int treeCounter = 0;
            string[] data = GetData(filePath);

            int stepX = 3;
            int stepY = 1;
            int maxX = data[0].Length;
            int maxY = data.Length;
            int currentX = 0;
            int currentY = 0;


            while (currentY < maxY) {
                if (currentX > maxX - 1)
                    currentX = currentX - maxX;

                if (data[currentY].Substring(currentX, 1) == tree)
                    treeCounter++;

                currentY += stepY;
                currentX += stepX;
            }

            return treeCounter;
        }

        public long GetSolutionTwo(string filePath) {

            long totalTreeCounter = 1;
            string[] data = GetData(filePath);

            
            int maxX = data[0].Length;
            int maxY = data.Length;
            
            List<int[]> runs = new List<int[]> {
                new int[] { 1, 1 },
                new int[] { 3, 1 },
                new int[] { 5, 1 },
                new int[] { 7, 1 },
                new int[] { 1, 2 }
            };

            foreach(var value in runs) {
                int stepX = value[0];
                int stepY = value[1];
                int currentX = 0;
                int currentY = 0;
                int treeCounter = 0;

                while (currentY < maxY) {
                    if (currentX > maxX - 1)
                        currentX = currentX - maxX;

                    if (data[currentY].Substring(currentX, 1) == tree)
                        treeCounter++;

                    currentY += stepY;
                    currentX += stepX;
                }

                totalTreeCounter *= treeCounter;
            }

            return totalTreeCounter;
        }

        private string[] GetData(string filePath) {
            return File.ReadAllLines(Directory.GetCurrentDirectory() + "/Inputs/" + filePath);
        }
    }
}
