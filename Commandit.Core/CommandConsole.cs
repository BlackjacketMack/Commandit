using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit
{
    public abstract class CommandConsole : ICommandConsole
    {
        public IEnumerable<ICommand> Commands
        {
            get;
            protected set;
        }

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
            if (this.Commands == null || !this.Commands.Any())
            {
                Console.WriteLine("You have not registered any commands.");
                return;
            }

            var commands = this.Commands.ToList();
            commands.Add(new HelpCommand(commands));
            commands.Add(new RunCommand(commands));

            this.Commands = commands;
        }

        private void welcome()
        {
            this.WriteLine("==================================================");
            this.WriteLine(_applicationName);
            this.WriteLine("[powered by Commandit]");
            this.WriteLine("");
            this.WriteLine("Current commands:");
            this.WriteLine(String.Join(" | ",this.Commands.Select(s=>s.Name)));
            this.WriteLine("(Type 'help' to see a command details)");
            this.WriteLine("==================================================");
        }

        private void listen()
        {
            var input = this.ReadLine();

            try
            {
                var parameters = parseInput(input);

                var command = getCommand(parameters);

                var logger = new CommandLogger(this);

                var context = new CommandContext(logger, parameters, command);

                if (parameters.Name == "quit")
                {
                    Console.WriteLine("Goodbye");

                    return;
                }
                else if (command != null) 
                {
                    runCommand(context);
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
                command = this.Commands.Where(w => w.Name.ToLower() == parameters.Name.ToLower()).Single();
            }
            catch (Exception ex)
            {
                this.WriteLine(ex.Message);
            }

            return command;
        }

        private void runCommand(ICommandContext context)
        {
            var commandName = context.Command.Name;

            this.WriteLine("** " + commandName + " Command **");

            context.Command.Run(context);

            this.WriteLine("--");
        }
    }
}
