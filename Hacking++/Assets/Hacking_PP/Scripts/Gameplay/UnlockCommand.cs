using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCommand : Command {
	public UnlockCommand(CommandInterpreter i) : base(i) { }

    public override string GetHelpString()
    {
        return "Unlocks the bank account on this computer";
    }

    public override void Execute(params string[] args)
	{
		if (PlayerStats.instance.connectedComputer == null || PlayerStats.instance == null) {
			Print ("Connect to a computer using connect [ip].");
			return;
		}
		else if (args.Length == 0 && PlayerStats.instance.connectedComputer.lockType != 1)
		{
			Print("Please specify your password, citizen.");
			return;
		}

		//Alpha
		if (PlayerStats.instance.connectedComputer.lockType == 1 && args.Length == 0) {
			Print ("Your Alpha-Protected account has been unlocked.");
			PlayerStats.instance.connectedComputer.unlockStatus = true;
		}

		//Beta
		if (PlayerStats.instance.connectedComputer.lockType == 2) {
			if (args [0] == "desert") {
				Print ("Your Beta-Protected account has been unlocked.");
				PlayerStats.instance.connectedComputer.unlockStatus = true;
			} else {
				//beta is very lenient.
				Print ("Wrong Password, please attempt again.");
			}
		}
	}
}