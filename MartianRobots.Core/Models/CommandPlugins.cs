using MartianRobots.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace MartianRobots.Core.Models
{
    /// <summary>
    /// Class to register and store plugins
    /// </summary>
    public class CommandPlugins : Dictionary<char, IRobotInstruction>
    {
        /// <summary>
        /// Registers a command plugin
        /// </summary>
        /// <typeparam name="T">Type of command plugin</typeparam>
        public void AddPlugin<T>()
        {
            if (typeof(IRobotInstruction).IsAssignableFrom(typeof(T)))
            {
                var instruction = (IRobotInstruction)Activator.CreateInstance(typeof(T));
                if (instruction != null)
                {
                    char commandChar = instruction.GetInstructionChar();
                    this.Add(commandChar, instruction);
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            else
            {
                throw new InvalidCastException(
                    "Trying to register plugin that does not support IRobotInstruction interface");
            }
        }
    }
}
