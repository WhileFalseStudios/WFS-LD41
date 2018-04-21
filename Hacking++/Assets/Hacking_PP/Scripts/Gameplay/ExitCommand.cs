using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCommand : Command {
	public ExitCommand(CommandInterpreter i) : base(i) { }

    public override string GetHelpString()
    {
        return "Shut down the computer";
    }

    public override void Execute(params string[] args)
	{
		Application.Quit ();
	}
}
