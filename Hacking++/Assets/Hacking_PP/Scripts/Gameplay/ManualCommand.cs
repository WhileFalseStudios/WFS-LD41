using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualCommand : Command
{
    public ManualCommand(CommandInterpreter i) : base(i) { }

    public static string GetLockManualDescription(int lockLevel)
    {
        switch (lockLevel)
        {
            case 0:
                return "This lock is an old system, kept in for legacy purposes. Simply use 'unlock' to unlock them.\nWhile locks typically take parameters, the alpha lock does not require them.";
            case 1:
                return "The rudimentary beta lock has the same password across every system. It is effective against tech-ignorant attackers.\nThe password is simply 'desert' - use 'unlock desert' to break it.";
            case 2:
                return "A terrible option if you want to secure something, this lock takes in a number from 0 to 9 (inclusive) as a password.\nYou will need to brute force (or script) to make this tedious lock less tedious.\nEg, ‘unlock 2’ or ‘unlock 4’.";
            case 3:
                return "A bit better than its predecessors, the delta lock locks accounts by applying a number between 1 - 99 (inclusive) from the Fibonacci sequence.\nEg, 1, 2, 3, 5, 8... use unlock [number] for this.";
			case 4:
				return "The first lock that cannot be easily brute forced.\nThe echo lock combines the charlie and delta systems system to increase combinations.\nThe first argument should be a number from 0 to 9 (inclusive) and the second argument is a number from the Fibonacci sequence.\nEg, 'unlock 4 81'";
			default:
                return "You've done something insane, this isn't a real lock type.";
        }
    }

    public static string GetLockManualTitle(int lockLevel)
    {
        switch (lockLevel)
        {
            case 0:
                return "Alpha Lock";
            case 1:
                return "Beta Lock";
            case 2:
                return "Charlie Lock";
            case 3:
                return "Delta Lock";
			case 4:
				return "Echo Lock";
            default:
                return "Not a real lock!";
        }
    }

    public override string GetHelpString()
    {
        return "Explains how each lock type works. You need to buy manuals before using this.";
    }

    public override void Execute(params string[] args)
    {
        if (args.Length == 0)
        {
            Print("You need to specify a lock type in the manual! Try man 'alpha'.");
            return;
        }
        if (args[0].ToLower() == "alpha")
        {
            Print(GetLockManualDescription(0));
        }
        if (args[0].ToLower() == "beta")
        {
            if (PlayerStats.instance.betaManual == true)
            {
                Print(GetLockManualDescription(1));
            }
            else
            {
                Print("Please purchase the Beta Lock Manual from the shop.");
            }
        }
        if (args[0].ToLower() == "charlie")
        {
            if (PlayerStats.instance.charlieManual == true)
            {
				Print(GetLockManualDescription(2));
            }
            else
            {
                Print("Please purchase the Charlie Lock Manual from the shop.");
            }
        }
		if (args[0].ToLower() == "delta")
		{
			if (PlayerStats.instance.deltaManual == true)
			{
				Print (GetLockManualDescription(3));
			}
			else
			{
				Print("Please purchase the Delta Lock Manual from the shop.");
			}
		}
		if (args[0].ToLower() == "echo")
		{
			if (PlayerStats.instance.deltaManual == true)
			{
				Print (GetLockManualDescription(4));
			}
			else
			{
				Print("Please purchase the Echo Lock Manual from the shop.");
			}
		}
    }
}
