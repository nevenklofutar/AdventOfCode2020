using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Solutions.HelperClasses;

namespace Solutions.Classes {
    public class Solution11 {

        private const char seatFree = 'L';
        private const char seatFloor = '.';
        private const char seatTaken = '#';

        public int GetSolutionOne(string filePath) {

            char[,] data = GetData(filePath);
            char[,] newdata; // = MakeNewData(data.Count, data[0].Length);
            int counter = 0;


            while (true) {

                newdata = ProcessDataSolutionOne(data);
                counter++;

                if (AreSeatingArrangemetsSame(data, newdata)) {
                    break;
                }

                data = (char[,])newdata.Clone();
            }

            return GetSeatsCount(data, seatTaken);
        }

        private char[,] GetData(string filePath) {
            string[] data = File.ReadAllLines(Directory.GetCurrentDirectory() + "/Inputs/" + filePath);

            char[,] result = new char[data.Length, data[0].Length];

            for (int row = 0; row < data.Length; row++) {
                for (int col = 0; col < data[row].Length; col++) {
                    result[row, col] = data[row][col];
                }
            }

            return result;
        }

        private char[,] ProcessDataSolutionOne(char[,] sourceData) {

            int dataRowCount = sourceData.GetLength(0);
            int dataColCount = sourceData.GetLength(1);

            char[,] newData = (char[,])sourceData.Clone(); // MakeNewData(dataRowCount, dataColCount);

            for (int rowIndex = 0; rowIndex < dataRowCount; rowIndex++) {
                for (int colIndex = 0; colIndex < dataColCount; colIndex++) {

                    char currentSeat = sourceData[rowIndex, colIndex];

                    if (currentSeat == seatFloor)
                        continue;

                    int adjecentOccupiedSeatsCount = GetAdjecentOccupiedSeatsCount(ref sourceData, rowIndex, colIndex);

                    // If a seat is empty(L) and there are no occupied seats adjacent to it, the seat becomes occupied.
                    if (currentSeat == seatFree && adjecentOccupiedSeatsCount == 0)
                        newData[rowIndex, colIndex] = seatTaken;

                    // If a seat is occupied(#) and four or more seats adjacent to it are also occupied, the seat becomes empty.
                    else if (currentSeat == seatTaken && adjecentOccupiedSeatsCount >= 4)
                        newData[rowIndex, colIndex] = seatFree;

                    // Otherwise, the seat's state does not change.
                    else
                        newData[rowIndex, colIndex] = sourceData[rowIndex, colIndex];
                }
            }

            return newData;
        }

        private int GetAdjecentOccupiedSeatsCount(ref char[,] data, int rowIndex, int colIndex) {

            int seatsCount = 0;
            int dataRowCount = data.GetLength(0);
            int dataColCount = data.GetLength(1);

            for (int row = rowIndex - 1; row <= rowIndex + 1; row++) { 
                for (int col = colIndex - 1; col <= colIndex + 1; col++) {
                    if (row >= 0 && row < dataRowCount && col >= 0 && col < dataColCount && data[row, col] == seatTaken)
                        seatsCount++;
                }
            }

            if (data[rowIndex, colIndex] == seatTaken)
                seatsCount--;

            return seatsCount;
        }

        private char[,] MakeNewData(int rowCount, int colCount) {

            char[,] result = new char[rowCount, colCount];

            for (int i = 0; i < rowCount; i++) { 
                for (int j = 0; j < colCount; j++) {
                    result[i, j] = '-';
                }
            }

            return result;
        }

        private bool AreSeatingArrangemetsSame(char[,] dataOne, char[,] dataTwo) {

            int dataRowCount = dataOne.GetLength(0);
            int dataColCount = dataOne.GetLength(1);

            for (int row = 0; row < dataRowCount; row++)
                for (int col = 0; col < dataColCount; col++)
                    if (dataOne[row, col] != dataTwo[row, col])
                        return false;

             return true;
        
        }

        private int GetSeatsCount(char[,] data, char seat) {

            int seatCount = 0;
            int dataRowCount = data.GetLength(0);
            int dataColCount = data.GetLength(1);

            for (int row = 0; row < dataRowCount; row++)
                for (int col = 0; col < dataColCount; col++)
                    if (data[row, col] == seat)
                        seatCount++;

            return seatCount;
        }

    }
}
