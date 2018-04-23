using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCommand : Command
{
    public TutorialCommand(CommandInterpreter i) : base(i) { }

    public override void Execute(params string[] args)
    {
        if (args.Length == 0)
        {
            Print("Your objective is to acquire all the lock manuals and as much wealth as you possibly can.\nTo do this, you need to hack, and buy your way through.\nType 'tutorial 1' for the next page - tutorial pages go up to 4.");
            return;
        }

        int v = 0;
        if (int.TryParse(args[0], out v))
        {
            if (v == 1)
            {
                Print("Basic commands - 'balance' to check your cash, 'shop' to see what's for sale, 'buy [index]' to buy items.\n'help' also contains a list of commands.\nType 'tutorial 2' to continue.");
            }
            else if (v == 2)
            {
                Print("To get money, you need to hack computers. To do this, write 'list' to list IPs. Next, use 'connect [ip]' to connect to a computer.\nUse 'target' to confirm that you are connected to a computer.\nAfter this, use 'scan' to see the lock level and the balance the computer has.\nType 'tutorial 3' to continue.");
            }
            else if (v == 3)
            {
                Print("If the lock is Alpha, the instructions to unlock it is in the manual - 'man alpha'.\nAlpha lock manual is automatically unlocked by default, but you will need to buy other lock manuals in the shop.\nIf it is beta, 'disconnect' and reconnect again.\nIt is currently too high level for you to unlock.\nType 'tutorial 4' to continue.");
            }
            else if (v == 4)
            {
                Print("Once you have unlocked it, use 'withdraw' to withdraw your money, and 'disconnect' from the computer. Good luck.");
            }
            else
            {
                Print("Invalid tutorial index! Try 0 - 4.");
            }
        }
        else
        {
            Print("Invalid tutorial index! Try 0 - 4.");
        }
    }

    public override string GetHelpString()
    {
        return "Displays tutorial. Use tutorial [index] to browse.";
    }
}