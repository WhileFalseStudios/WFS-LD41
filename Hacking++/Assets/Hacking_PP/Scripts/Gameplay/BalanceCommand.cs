using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceCommand : Command
{
    public BalanceCommand(CommandInterpreter i) : base(i) { }

    public override void Execute(params string[] args)
    {
        if (PlayerStats.instance != null)
        {
            Print(string.Format("Your balance is {0}cc", PlayerStats.instance.bankBalance));
        }
    }

    public override string GetHelpString()
    {
        return "Displays your citizen credit balance.";
    }
}