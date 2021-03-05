using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Solutions.Classes {
    public class Solution12 {

        public int GetSolutionOne(string filePath) {

            List<string> data = GetData(filePath);
            List<ShipCommand> shipCommands = GetShipCommands(data);

            ShipComputer sc = new ShipComputer(shipCommands);
            sc.MoveShipOne();
            return sc.CalculateManhattanDistance();
        }

        private List<string> GetData(string filePath) {
            return File.ReadAllLines(Directory.GetCurrentDirectory() + "/Inputs/" + filePath).ToList();
        }

        private List<ShipCommand> GetShipCommands(List<string> data) {

            List<ShipCommand> commands = new List<ShipCommand>();

            foreach (var line in data) {
                ShipCommand sc = new ShipCommand {
                    Command = line.Substring(0, 1),
                    Value = Convert.ToInt32(line.Substring(1))
                };

                commands.Add(sc);
            }

            return commands;
        }

    }

    public class ShipCommand {

        public string Command { get; set; }
        public int Value { get; set; }
    }

    public class ShipComputer {

        private int facing = 90;

        private int coordX = 0;
        private int coordY = 0;

        private int waypointCoordX = 1;
        private int waypointCoordY = 10;

        private List<ShipCommand> shipCommands;

        public ShipComputer(List<ShipCommand> commands) {
            shipCommands = commands;
        }

        public void MoveShipOne() {

            foreach (var command in shipCommands) {
                if (command.Command == "N") {
                    coordX += command.Value;
                }
                else if (command.Command == "S") {
                    coordX -= command.Value;
                }
                else if (command.Command == "W") {
                    coordY -= command.Value;
                }
                else if (command.Command == "E") {
                    coordY += command.Value;
                }
                else if (command.Command == "L") {
                    facing = facing - command.Value;
                    if (facing < 0)
                        facing += 360;
                }
                else if (command.Command == "R") {
                    facing = facing + command.Value;
                    if (facing >= 360)
                        facing -= 360;
                }
                else if (command.Command == "F") {
                    if (facing == 0)
                        coordX += command.Value;
                    if (facing == 90)
                        coordY += command.Value;
                    if (facing == 180)
                        coordX -= command.Value;
                    if (facing == 270)
                        coordY -= command.Value;
                }
            }
        }

        public void MoveShipTwo() {

            foreach (var command in shipCommands) {
                if (command.Command == "N") {
                    waypointCoordX += command.Value;
                }
                else if (command.Command == "S") {
                    waypointCoordX -= command.Value;
                }
                else if (command.Command == "W") {
                    waypointCoordX -= command.Value;
                }
                else if (command.Command == "E") {
                    waypointCoordX += command.Value;
                }
                else if (command.Command == "L") {
                    facing = facing - command.Value;
                    if (facing < 0)
                        facing += 360;
                }
                else if (command.Command == "R") {
                    facing = facing + command.Value;
                    if (facing >= 360)
                        facing -= 360;
                }
                else if (command.Command == "F") {
                    if (facing == 0)
                        coordX += command.Value;
                    if (facing == 90)
                        coordY += command.Value;
                    if (facing == 180)
                        coordX -= command.Value;
                    if (facing == 270)
                        coordY -= command.Value;
                }
            }
        }

        public int CalculateManhattanDistance() {

            return Math.Abs(coordX) + Math.Abs(coordY);
        }
    
    }
}
