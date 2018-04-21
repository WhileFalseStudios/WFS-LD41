using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DisconnectCommand : Command
{
    public DisconnectCommand(CommandInterpreter i) : base(i) { }

    public override string GetHelpString()
    {
        return "Disconnect from a computer, if connected.";
    }

    public override void Execute(params string[] args)
    {
        if (PlayerStats.instance != null)
        {
            if (PlayerStats.instance.connectedComputer != null)
            {
                string connectedIP = PlayerStats.instance.connectedComputer.computerIP;
                PlayerStats.instance.connectedComputer = null;
                Print(string.Format("Disconnected from {0}", connectedIP));
            }
            else
            {
                Error("No computer to disconnect from.");
            }
        }
    }
}