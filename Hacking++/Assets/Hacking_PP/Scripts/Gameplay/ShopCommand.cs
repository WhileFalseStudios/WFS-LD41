using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCommand : Command {
	public ShopCommand(CommandInterpreter i) : base(i) { }

    public override string GetHelpString()
    {
        return "Lists items available for sale in the Responsible Citizenship Scheme!";
    }

    public override void Execute(params string[] args)
	{
		Print ("Welcome to the dispensary store regulated by the Responsible Citizenship Scheme! Spend your hardearned Citizen Credits.");
		Print ("Listing all avaliable shop items.");
		Print ("To buy, use buy [index].");
		if (ShopController.instance != null)
        {
            foreach (var i in ShopController.instance.itemNameTable)
            {
                Print(string.Format("{0}: {1} ({2}cc)", (int)i.Key, i.Value.name, i.Value.cost));
            }
        }
	}
}