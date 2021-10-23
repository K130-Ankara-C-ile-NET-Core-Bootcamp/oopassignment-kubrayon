using System;
using OOPAssignment.Interfaces;
using OOPAssignment.structs;

namespace OOPAssignment.Class
{
    public class CarStringCommandExecutor : CarCommandExecutorBase, IStringCommand
    {
        public CarStringCommandExecutor(ICarCommand carCommand) : base(carCommand)
        {

        }
        public void ExecuteCommand(string commandObject)
        {
            if (string.IsNullOrEmpty(commandObject))
                throw new Exception("Komutlarda hata var.");

            char[] commands = commandObject.ToCharArray();

            for (int i = 0; i < commands.Length; i++)
            {

                if (commands[i] == 'L')
                    CarCommand.TurnLeft();
                else if (commands[i] == 'R')
                    CarCommand.TurnRight();
                else if (commands[i] == 'M')
                {
                    MovementFactor move = new();
                    CarCommand.Move();
                }
                else
                {
                    throw new Exception("Komutlarda hata var.");
                }
            }
        }
    }
}