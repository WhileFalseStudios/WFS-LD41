using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualCommand : Command
{
    public ManualCommand(CommandInterpreter i) : base(i) { }

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
            Print("This lock is an old system, kept in for legacy purposes. Simply use unlock to unlock them.\nWhile locks typically take parameters, the alpha lock does not require them.");
        }
        if (args[0].ToLower() == "beta")
        {
            if (PlayerStats.instance.betaManual == true)
            {
                Print("The rudimentary beta lock has the same password across every system. It is effective against tech-ignorant attackers.\nThe password is simply 'desert' - use 'unlock desert' to break it.");
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
                Print("Placeholder, woo!");
            }
            else
            {
                Print("Please purchase the Charlie Lock Manual from the shop.");
            }
        }
    }
}
