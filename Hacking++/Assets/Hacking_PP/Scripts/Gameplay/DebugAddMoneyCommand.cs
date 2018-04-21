using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DebugAddMoneyCommand : Command
{
    public DebugAddMoneyCommand(CommandInterpreter i) : base(i) { }

    public override string GetHelpString()
    {
        return "You shouldn't be reading this.";
    }

    public override void Execute(params string[] args)
    {
        if (args.Length == 0) return;

        int v = 0;
        if (!int.TryParse(args[0], out v))
            return;

        if (PlayerStats.instance != null)
        {
            PlayerStats.instance.AddBalance(v);
            Print(string.Format("Added {0} to balance, new balance is {1}", v, PlayerStats.instance.bankBalance));
        }
    }
}
