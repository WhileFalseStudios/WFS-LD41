using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TargetCommand : Command
{
    public TargetCommand(CommandInterpreter i) : base(i) { }

    public override string GetHelpString()
    {
        return "Displays the IP of the computer you are connected to.";
    }

    public override void Execute(params string[] args)
    {
        if (PlayerStats.instance != null)
        {
            if (PlayerStats.instance.connectedComputer == null)
            {
                Print("You are not connected to another computer.");
            }
            else
            {
                Print(string.Format("You are connected to {0}", PlayerStats.instance.connectedComputer.computerIP));
            }
        }
    }
}
