using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCommand : Command {
	public ShopCommand(CommandInterpreter i) : base(i) { }

	public override void Execute(params string[] args)
	{
		Print ("Listing all avaliable shop items.");
		Print ("To buy, use buy [index].");
		Print ("Beta Lock Manual     10cc   - 1");
		Print ("Charlie Lock Manual  100cc  - 2");
		Print ("Delta Lock Manual    1000cc - 3");
		Print ("System Time Module   50cc   - 4");
		Print ("Manual System Module 300cc  - 5");
	}
}
