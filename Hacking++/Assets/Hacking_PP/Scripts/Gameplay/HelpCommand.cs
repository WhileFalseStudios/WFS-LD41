using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HelpCommand : Command
{
    public HelpCommand(CommandInterpreter i) : base(i) { }

    public override void Execute(params string[] args)
    {
        if (args.Length > 0)
        {
            Print(string.Format("Help for command {0}:", args[0]));
        }
        else
        {
            Error("Please specify a command you want help for."); //TODO: no, just print them all!
        }
    }
}
