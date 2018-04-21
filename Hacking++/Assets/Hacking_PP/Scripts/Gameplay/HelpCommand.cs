using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HelpCommand : Command
{
    public HelpCommand(CommandInterpreter i) : base(i) { }

    public override string GetHelpString()
    {
        return "Lists all commands available in the system.";
    }

    public override void Execute(params string[] args)
    {
        Print("Listing all available commands:");
        foreach (var cmd in interpreter.commandTable)
        {
            Print(string.Format("{0}: {1}", cmd.Key, cmd.Value.GetHelpString()));
        }
    }
}
