using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithdrawCommand : Command {
	public WithdrawCommand(CommandInterpreter i) : base(i) { }

    public override string GetHelpString()
    {
        return "Transfer money from this account to yours.";
    }

    public override void Execute(params string[] args)
	{
		if (PlayerStats.instance.connectedComputer == null || PlayerStats.instance == null) {
			Print ("Connect to a computer before you withdraw.");
			return;
		}

        if (PlayerStats.instance.connectedComputer.unlockStatus == true && !PlayerStats.instance.connectedComputer.isLockedOut) {
			PlayerStats.instance.AddBalance (PlayerStats.instance.connectedComputer.hackBalance);
			//security so the player can't infinitely withdraw. god that'd be bad design
			string i = string.Format ("Successful withdrawal of {0}cc. Your spending is monitored, citizen.", PlayerStats.instance.connectedComputer.hackBalance);
			Print (i);
			PlayerStats.instance.connectedComputer.hackBalance = 0;
		} else {
			Print ("You have not logged into your account.");
		}
	}
}
