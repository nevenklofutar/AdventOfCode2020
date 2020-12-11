using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Solutions.Classes {
    public class Solution08 {

        public int GetSolutionOne(string filePath) {

            int result = 0;

            IList<string> data = GetData(filePath);
            IList<Instruction> instructions = GetInstructionsFromData(data);

            Computer computer = new Computer(instructions);
            result = computer.GetSolutionOne();

            return result;
        }

        public int GetSolutionTwo(string filePath) {

            int result = 0;

            IList<string> data = GetData(filePath);
            IList<Instruction> instructions = GetInstructionsFromData(data);

            Computer computer = new Computer(instructions);
            result = computer.GetSolutionTwo();

            return result;
        }

        private IList<string> GetData(string filePath) {
            return File.ReadAllLines(Directory.GetCurrentDirectory() + "/Inputs/" + filePath);
        }

        private IList<Instruction> GetInstructionsFromData(IList<string> data) {

            IList<Instruction> instructions = new List<Instruction>();

            foreach (var line in data) {
                var instruction = line.Split(' ');
                instructions.Add(new Instruction { Command = instruction[0], Value = int.Parse(instruction[1]) });
            }

            return instructions;
        }

    }

    public class Instruction {

        public string Command { get; set; }
        public int Value { get; set; } = 0;
        public bool Executed { get; set; } = false;
    }

    public class Computer {

        private IList<Instruction> _instructions;
        private int _value;
        private Instruction _currentInstruction;
        private int _currentIndex;
        private List<int> _switchedIndexes = new List<int>();
        private bool _switchExecuted = false;
        private string _currentCommand = string.Empty;

        public Computer(IList<Instruction> instructions) {
            _instructions = instructions;
        }

        private IList<string> GetData(string filePath) {
            return File.ReadAllLines(Directory.GetCurrentDirectory() + "/Inputs/" + filePath);
        }

        private IList<Instruction> GetInstructionsFromData(IList<string> data) {

            IList<Instruction> instructions = new List<Instruction>();

            foreach (var line in data) {
                var instruction = line.Split(' ');
                instructions.Add(new Instruction { Command = instruction[0], Value = int.Parse(instruction[1]) });
            }

            return instructions;
        }

        private void ResetOperation() {

            IList<string> data = GetData("Input08b.txt");
            _instructions = GetInstructionsFromData(data);

            _value = 0;
            _currentIndex = 0;
            _currentInstruction = _instructions[_currentIndex];
            _currentCommand = string.Empty;
            _switchExecuted = false;
        }

        public int GetSolutionOne() {

            int currentInstructionIndex = 0;
            Instruction instruction = _instructions[currentInstructionIndex];

            _value = 0;

            while (instruction.Executed == false) {

                instruction.Executed = true;
                switch (instruction.Command) {
                    case "nop":
                        // it does nothing. The instruction immediately below it is executed next.
                        currentInstructionIndex++;
                        break;
                    case "jmp":
                        // jumps to a new instruction relative to itself
                        currentInstructionIndex += (instruction.Value);
                        break;
                    case "acc":
                        _value += (instruction.Value);
                        currentInstructionIndex++;
                        break;
                    default: 
                        break;
                }

                instruction = _instructions[currentInstructionIndex];
            }

            return _value;
        }

        public int GetSolutionTwo() {

            ResetOperation();

            while (true) {

                _currentInstruction = _instructions[_currentIndex];

                if (_currentInstruction.Executed) {
                    //Console.WriteLine($"double: { _currentIndex }");
                    ResetOperation();
                }

                _currentCommand = _currentInstruction.Command;

                if (_switchedIndexes.Contains(_currentIndex) == false && _switchExecuted == false &&
                    (_currentInstruction.Command == "jmp" || _currentInstruction.Command == "nop")) {

                    _switchedIndexes.Add(_currentIndex);
                    _switchExecuted = true;

                    if (_currentInstruction.Command == "jmp")
                        _currentCommand = "nop";
                    else if (_currentInstruction.Command == "nop")
                        _currentCommand = "jmp";
                }

                _currentInstruction.Executed = true;

                switch (_currentCommand.ToLower()) {

                    case "acc":
                        _value += _currentInstruction.Value;
                        _currentIndex++;
                        break;
                    case "jmp":
                        _currentIndex += _currentInstruction.Value;
                        break;
                    case "nop":
                        _currentIndex++;
                        break;
                    default:
                        break;
                }

                if (_currentIndex >= _instructions.Count)
                    return _value;
            }

            return _value;
        }
    }
}
