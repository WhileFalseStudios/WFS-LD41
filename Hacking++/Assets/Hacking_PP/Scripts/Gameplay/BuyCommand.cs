using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCommand : Command
{
    public BuyCommand(CommandInterpreter i) : base(i) { }

    public override string GetHelpString()
    {
        return "Buy an item from the store.";
    }

    public override void Execute(params string[] args)
    {
        //error checking
        if (PlayerStats.instance == null)
        {
            Debug.LogWarning("No instance of PlayerStats available.");
            return;
        }
        else if (args.Length == 0)
        {
            Error("Please specify an item number.");
            return;
        }

        int v = 0;
        if (!int.TryParse(args[0], out v))
        {
            Error("Please enter a valid item number.");
            return;
        }

        if (ShopController.instance != null)
        {
            if (System.Enum.IsDefined(typeof(ShopController.ShopItem), v))
            {
                switch (ShopController.instance.BuyItem((ShopController.ShopItem)v))
                {
                    case ShopController.BuyCode.OK:
                        Print("Purchase successful!");
                        break;
                    case ShopController.BuyCode.AlreadyOwns:
                        Print("You already own this!");
                        break;
                    case ShopController.BuyCode.TooExpensive:
                        Print("You cannot afford this!");
                        break;                    
                }
            }
            else
            {
                Error("Please enter a valid item number.");
            }
        }
    }
}
