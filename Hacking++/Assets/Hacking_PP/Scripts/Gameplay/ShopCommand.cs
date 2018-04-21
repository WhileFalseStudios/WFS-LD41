using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCommand : Command {
	public ShopCommand(CommandInterpreter i) : base(i) { }

	public override void Execute(params string[] args)
	{
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
