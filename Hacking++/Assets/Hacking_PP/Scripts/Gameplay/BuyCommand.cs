using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCommand : Command {
	public BuyCommand(CommandInterpreter i) : base(i) { }

	public override void Execute(params string[] args)
	{
		//error checking
		if (PlayerStats.instance == null) {
			Print ("ERROR: PlayerStats is not instanced.");
			return;
		} else if (args.Length == 0) {
			Print ("ERROR: no arguments. Use buy [index number].");
			return;
		} else if (args.Length > 1) {
			Print ("ERROR: too many arguments. Use buy [index number].");
			return;
		}

		if (args [0] == "1") { //Beta lock
			if (PlayerStats.instance.bankBalance >= 10) {
				PlayerStats.instance.RemoveBalance (10);
				PlayerStats.instance.betaManual = true;
				Print ("Beta Lock Manual has been purchased. Thank you for your Citizen Credit Contribution.");
			} else {
				Print ("You are required to have more citizen credits. Optionally, notifying authorities about anti-social behaviour will give you 100cc.");
			}
		}
		if (args [0] == "2") { //Charlie lock
			if (PlayerStats.instance.bankBalance >= 100) {
				PlayerStats.instance.RemoveBalance (100);
				PlayerStats.instance.charlieManual = true;
				Print ("Charlie Lock Manual has been purchased. Thank you for your Citizen Credit Contribution.");
			} else {
				Print ("You are required to have more citizen credits. Optionally, notifying authorities about anti-social behaviour will give you 100cc.");
			}
		}
	}
}
