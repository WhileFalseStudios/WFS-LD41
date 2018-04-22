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
        if (PlayerStats.instance != null)
        {
            if (PlayerStats.instance.userScripts.ContainsKey(file.ToLower()))
            {
                Print(string.Format("Executing {0}...", file));
                interpreter.RunScript(file.ToLower());
            }
            else
            {
                Error("The given script does not exist.");
            }
        }
    }

    void NewScript(string file)
    {
        if (PlayerStats.instance != null)
        {
            if (PlayerStats.instance.userScripts.ContainsKey(file.ToLower()))
            {
                Error(string.Format("A script named {0} already exists.", file));                
            }
            else
            {
                PlayerStats.instance.userScripts.Add(file.ToLower(), new AutoScript(file));
                Print(string.Format("Created script named {0}", file));
            }
        }
    }

    void DeleteScript(string file)
    {
        if (PlayerStats.instance != null)
        {
            if (!PlayerStats.instance.userScripts.ContainsKey(file.ToLower()))
            {
                Error("The given script does not exist.");
            }
            else
            {
                PlayerStats.instance.userScripts.Remove(file.ToLower());
                Print(string.Format("Deleted script {0}", file));
            }
        }
    }

    void EditScript(string file)
    {
        if (PlayerStats.instance != null && ScriptEditor.instance != null)
        {
            if (!PlayerStats.instance.userScripts.ContainsKey(file.ToLower()))
            {
                Error("The given script does not exist.");
            }
            else
            {
                var script = PlayerStats.instance.userScripts[file.ToLower()];
                ScriptEditor.instance.Show();
                ScriptEditor.instance.SetScript(script);
            }
        }
        else
        {
            UnityEngine.Debug.LogError("Script editor is null. Most likely it is not having Awake() called.");
        }
    }
}
