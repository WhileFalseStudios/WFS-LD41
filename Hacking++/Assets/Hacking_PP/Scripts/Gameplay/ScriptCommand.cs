using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ScriptCommand : Command
{
    public ScriptCommand(CommandInterpreter i) : base(i)
    {
        Print("Congratulations! You have purchased the ConquerorSoft Script Engine 6.1!");
        Print("You can run this with 'script [subcommand] [file]'");
        Print("For information on subcommands, run 'script' without any parameters.");
    }

    public override string GetHelpString()
    {
        return "Use scripts to automate repetitive tasks.";
    }

    public override void Execute(params string[] args)
    {
        if (args.Length == 0)
        {
            Print("You need to specify a subcommand for script, in the format 'script [subcommand]'");
            Print("\t'exec [scriptname]': execute a named script.");
            Print("\t'new [scriptname]': create a new script with the given name.");
            Print("\t'delete [scriptname]': deletes an existing script.");
            Print("\t'edit [scriptname]': opens the editor for a script.");
            return;
        }

        if (args.Length == 1)
        {
            Error("This subcommand requires a name of a script as a parameter!");
            return;
        }

        if (PlayerStats.instance == null) //We can be sure its safe past here.
            return;

        string scriptName = args[1];

        switch (args[0].ToLower())
        {
            case "exec":
                ExecuteScript(scriptName);
                break;
            case "new":
                NewScript(scriptName);
                break;
            case "delete":
                DeleteScript(scriptName);
                break;
            case "edit":
                EditScript(scriptName);
                break;
        }
    }

    void ExecuteScript(string file)
    {

    }

    void NewScript(string file)
    {

    }

    void DeleteScript(string file)
    {

    }

    void EditScript(string file)
    {

    }
}
