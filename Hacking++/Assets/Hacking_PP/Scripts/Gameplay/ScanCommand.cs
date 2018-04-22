using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanCommand : Command {
	public ScanCommand(CommandInterpreter i) : base(i) { }

    public override string GetHelpString()
    {
        return "Evaluates this computer's lock type.";
    }

    public override void Execute(params string[] args)
	{
		if (PlayerStats.instance.connectedComputer != null && PlayerStats.instance != null) {
			string lockName = string.Empty;
			switch (PlayerStats.instance.connectedComputer.lockType) {
			case 1:
				lockName = "Alpha";
				break;
			case 2:
				lockName = "Beta";
				break;
			case 3:
				lockName = "Charlie";
				break;
			case 4:
				lockName = "Delta";
				break;
			case 5:
				lockName = "Echo";
				break;
			}

			string i = string.Format ("{0} has lock type {1}", PlayerStats.instance.connectedComputer.computerIP, lockName);
			string ii = string.Format ("There is {0}cc stored in the account balance.", PlayerStats.instance.connectedComputer.hackBalance);
			Print (i);
			Print (ii);
		} else {
			Print ("A valid IP must be connected to. Use connect [IP].");
			return;
		}
	}
}
