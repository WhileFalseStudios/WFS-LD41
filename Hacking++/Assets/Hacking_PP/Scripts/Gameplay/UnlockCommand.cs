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
		if (PlayerStats.instance.connectedComputer.lockType == 1) {
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

		if (PlayerStats.instance.connectedComputer.isLockedOut == true){
			Print ("Violator, you have been locked out. Refrain from further attempts to unlock and do not move.");
			return;
		}

		//Charlie
		if (PlayerStats.instance.connectedComputer.lockType == 3) {
			string s = string.Format ("{0}", PlayerStats.instance.connectedComputer.charliePass);
			if (args [0] == s) {
				Print ("Your Charlie-Protected account has been unlocked.");
				PlayerStats.instance.connectedComputer.unlockStatus = true;
			} else {
				//charlie is an acting script tester
				Print ("You have given an incorrect parameter. Unauthorised access will lead to punishment.");
			}
		}
		//delta
		if (PlayerStats.instance.connectedComputer.lockType == 4) {
			string ss = string.Format ("{0}", PlayerStats.instance.connectedComputer.deltaPass);
			if (args [0] == ss) {
				Print ("Your Delta-Protected account has been unlocked.");
				PlayerStats.instance.connectedComputer.unlockStatus = true;
			} else {
				Print ("You have given an incorrect parameter. Unauthorised access will lead to punishment.");
				PlayerStats.instance.connectedComputer.playerTries++;
				if (PlayerStats.instance.connectedComputer.deltaAttempts - PlayerStats.instance.connectedComputer.playerTries > 0) {
					string sss = string.Format ("You have {0} attempts remaining before authorities are notified.", PlayerStats.instance.connectedComputer.deltaAttempts - PlayerStats.instance.connectedComputer.playerTries);
					Print (sss);
					return;
				}
				else{
					Print("You have been locked out. Authorities have been alerted.");
					PlayerStats.instance.connectedComputer.isLockedOut = true;
					return;
				}
			}
		}
		//echo
		if (PlayerStats.instance.connectedComputer.lockType == 5) {
			string pass1 = string.Format ("{0}", PlayerStats.instance.connectedComputer.echoPassOne);
			string pass2 = string.Format ("{0}", PlayerStats.instance.connectedComputer.echoPassTwo);
			if (args [0] == pass1 && args[1] == pass2) {
				Print ("Your Echo-Protected account has been unlocked.");
				Print ("You win the game.");
				PlayerStats.instance.connectedComputer.unlockStatus = true;
			} else {
				Print ("Echo is infinitely secure - you will be unable to breach this, intruder.");
			}
		}
	}
}