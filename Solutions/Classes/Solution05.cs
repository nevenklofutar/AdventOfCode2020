using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Solutions.Classes {
    public class Solution05 {

        public int GetSolutionOne(string filePath) {

            int result = 0;
            int lowestSeatId = 1000;

            string[] data = GetData(filePath);
            List<int> seats = new List<int>();

            foreach(var row in data) {
                int rowNumber = GetRowNumber(row.Substring(0, 7));
                int seatNumber = GetSeatNumber(row.Substring(7));

                RowSeat rs = new RowSeat() { Row = rowNumber, Seat = seatNumber };
                seats.Add(rs.SeatId);
                seats.Sort();

                if (rs.SeatId > result)
                    result = rs.SeatId;
                if (rs.SeatId < lowestSeatId)
                    lowestSeatId = rs.SeatId;
            }

            return result;
        }

        public int GetSolutionTwo(string filePath) {

            int result = 0;

            string[] data = GetData(filePath);
            List<int> seats = new List<int>();

            foreach (var row in data) {
                int rowNumber = GetRowNumber(row.Substring(0, 7));
                int seatNumber = GetSeatNumber(row.Substring(7));

                RowSeat rs = new RowSeat() { Row = rowNumber, Seat = seatNumber };
                seats.Add(rs.SeatId);
            }

            seats.Sort();

            for (int counter = seats[0]; counter < seats[seats.Count - 1]; counter++) {
                if (!seats.Contains(counter) && seats.Contains(counter - 1) && seats.Contains(counter + 1))
                    result = counter;
            }

            return result;
        }

        private int GetRowNumber(string data) {

            int leftBound = 0;
            int rightBound = 127;

            foreach (var command in data.ToLower()) {
                if (command == 'f')
                    rightBound = ((leftBound + rightBound) + 1) / 2 - 1;
                if (command == 'b')
                    leftBound = ((leftBound + rightBound) + 1) / 2;
            }

            return leftBound;
        }

        private int GetSeatNumber(string data) {

            int leftBound = 0;
            int rightBound = 7;

            foreach (var command in data.ToLower()) {
                if (command == 'l')
                    rightBound = ((leftBound + rightBound) + 1) / 2 - 1;
                if (command == 'r')
                    leftBound = ((leftBound + rightBound) + 1) / 2;
            }

            return leftBound;
        }

        private string[] GetData(string filePath) {
            return File.ReadAllLines(Directory.GetCurrentDirectory() + "/Inputs/" + filePath);
        }
    }

    public class RowSeat {
        public int Row { get; set; }
        public int Seat { get; set; }

        public int SeatId { get { return Row * 8 + Seat; } }
    }
}
