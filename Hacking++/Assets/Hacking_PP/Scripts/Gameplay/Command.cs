using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Command
{
    protected CommandInterpreter interpreter { get; private set; }

    public Command(CommandInterpreter i)
    {
        interpreter = i;
    }

    public virtual void Execute(params string[] args) { }

    protected void Print(string msg)
    {
        if (TerminalController.instance != null)
        {
            TerminalController.instance.Print(msg);
        }
    }

    protected void Error(string msg)
    {
        if (TerminalController.instance != null)
        {
            TerminalController.instance.Error(msg);
        }
    }
}
