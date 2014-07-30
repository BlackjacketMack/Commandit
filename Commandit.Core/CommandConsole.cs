﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit
{
    public abstract class CommandConsole
    {
        public IEnumerable<ICommand> Commands
        {
            get;
            protected set;
        }

        private IDictionary<CommandAttribute, ICommand> _commandDictionary = new Dictionary<CommandAttribute, ICommand>();

        private string _applicationName;

        public CommandConsole(string applicationName)
        {
            _applicationName = applicationName;
        }

        public virtual void Init()
        {
            load();

            welcome();

            listen();
        }

        private void load()
        {
            var commands = this.Commands.Concat(new[] { new HelpCommand(_commandDictionary) });

            foreach (var command in commands)
            {
                var attribute = command.GetType().GetCustomAttributes(typeof(CommandAttribute),false).Cast<CommandAttribute>().FirstOrDefault();

                if (attribute == null)
                {
                    attribute = new CommandAttribute { Name = command.GetType().Name };
                }

                _commandDictionary.Add(attribute, command);
            }
        }

        private void welcome()
        {
            this.WriteLine("==================================================");
            this.WriteLine(_applicationName);
            this.WriteLine("(powered by Commandit)");
            this.WriteLine("");
            this.WriteLine("Type 'help' to see a list of registered commands.");
            this.WriteLine("==================================================");
        }

        private void listen()
        {
            var input = this.ReadLine();

            try
            {
                var parameters = parseInput(input);

                var command = getCommand(parameters);


                if (command != null) { 
                    runCommand(command,parameters);
                }

            }
            catch (Exception ex)
            {
                this.WriteError(ex.Message);
            }

            listen();
        }

        private CommandParameters parseInput(string input)
        {
            var inputSplit = input.Split(' ').ToList();

            var command = new CommandParameters();
            command.Name = inputSplit[0].ToLower();
            command.Attributes = CommandParameters.ParseAttributes(input);

            return command;
        }

        private ICommand getCommand(CommandParameters parameters)
        {
            ICommand command = null;
            try 
            { 
                command = _commandDictionary.Where(w => w.Key.Name.ToLower() == parameters.Name.ToLower()).Single().Value;
            }
            catch (Exception ex)
            {
                this.WriteLine(ex.Message);
            }

            return command;
        }

        private void runCommand(ICommand command, CommandParameters parameters)
        {
            command.Run(parameters);

            this.WriteLine("--");
        }

        #region Util

        public void WriteLine(string message, string lineBreak = null)
        {
            Console.WriteLine(message);

            if (lineBreak != null)
            {
                Console.WriteLine(lineBreak);
            }
        }

        public string ReadParameters(string message, params string[] allowedParameters)
        {
            Console.WriteLine("");
            Console.Write(message);

            var input = Console.ReadLine()
                               .Trim()
                               .ToLowerInvariant();

            if (allowedParameters.Any() && !allowedParameters.Contains(input))
            {
                Console.WriteLine("Unknown input...");
                input = ReadParameters(message, allowedParameters);
            }

            return input;
        }

        public string ReadLine()
        {
            return Console.ReadLine()
                               .Trim()
                               .ToLowerInvariant();
        }

        public void WriteError(string message)
        {
            Console.WriteLine("ERROR: " + message);
        }

        public bool Confirm()
        {
            var input = ReadParameters("Is this correct? (yes | no)", "yes", "no");

            if (input == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}