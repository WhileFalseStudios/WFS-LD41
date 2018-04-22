using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ClearCommand : Command
{
    public ClearCommand(CommandInterpreter i) : base(i) { }

    public override string GetHelpString()
    {
        return "Clears the screen.";
    }

    public override void Execute(params string[] args)
    {
        for (int i = 0; i < TerminalController.MAX_BUFFER_COUNT; i++)
        {
            Print("");
        }
    }
}
