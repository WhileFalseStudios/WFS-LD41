using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ConnectCommand : Command
{
    public ConnectCommand(CommandInterpreter i) : base(i) { }

    public override string GetHelpString()
    {
        return "Connect to a valid IP";
    }

    public override void Execute(params string[] args)
    {
        if (args.Length == 0)
        {
            Error("Please specify an IP to connect to.");
            return;
        }

        if (PlayerStats.instance != null)
        {
            if (PlayerStats.instance.lastGeneratedIPSet != null && PlayerStats.instance.lastGeneratedIPSet.Contains(args[0]))
            {
                PlayerStats.instance.connectedComputer = new Computer(args[0]);
                Print(string.Format("Connected to {0} successfully.", args[0]));
            }
            else
            {
                Error(string.Format("Could not connect to {0}", args[0]));
            }
        }
    }
}
