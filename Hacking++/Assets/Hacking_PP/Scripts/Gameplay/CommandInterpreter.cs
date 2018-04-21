using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CommandInterpreter : MonoBehaviour
{
    public static CommandInterpreter instance { get; private set; }

    Dictionary<string, Command> commands = new Dictionary<string, Command>();
    public Dictionary<string, Command> commandTable {get { return commands; } }

    private void Awake()
    {       
        if (instance == null)
        {
            instance = this;
            commands.Add("help", new HelpCommand(this));
            commands.Add("balance", new BalanceCommand(this));
			commands.Add("shop", new ShopCommand(this));
			commands.Add("exit", new ExitCommand(this));
			commands.Add("man", new ManualCommand(this));
			commands.Add("buy", new BuyCommand(this));
            commands.Add("list", new ListIpCommand(this));
            commands.Add("connect", new ConnectCommand(this));
            commands.Add("disconnect", new DisconnectCommand(this));
            commands.Add("target", new TargetCommand(this));
            commands.Add("scan", new ScanCommand(this));
            commands.Add("unlock", new UnlockCommand(this));
            commands.Add("withdraw", new WithdrawCommand(this));
#if UNITY_EDITOR
            commands.Add("addmoney", new DebugAddMoneyCommand(this));
#endif
        }
        else
        {
            Debug.LogWarning("Multiple command intepreters exist!");
        }
    }

    public void AddNewCommand<T>(string name) where T : Command
    {
        if (!commands.ContainsKey(name))
        {
            T cmd = (T)System.Activator.CreateInstance(typeof(T), new object[] { this });
            commands.Add(name, cmd);
        }
    }

    public void InterpretCommand(string inputString)
    {
        string commandName = string.Empty;
        List<string> args = new List<string>();
        int item = 0;
        bool isInQuotedString = false;
        StringBuilder sb = new StringBuilder();

        foreach (var c in inputString.TrimStart(' ', '\t'))
        {
            if (c == '\"')
            {
                isInQuotedString = !isInQuotedString;
                continue;
            }

            if (char.IsWhiteSpace(c) && !isInQuotedString)
            {
                if (item == 0)
                {
                    commandName = sb.ToString();
                }
                else
                {
                    args.Add(sb.ToString());
                }

                sb.Remove(0, sb.Length);
                item++;
                continue;
            }

            sb.Append(c);
        }

        if (sb.Length > 0) //Flush the end of the buffer into the last arg
        {
            if (item == 0)
            {
                commandName = sb.ToString();
            }
            else
            {
                args.Add(sb.ToString());
            }
        }

        if (commands.ContainsKey(commandName.ToLower()))
        {
            commands[commandName.ToLower()].Execute(args.ToArray());
        }
        else
        {
            if (TerminalController.instance != null)
            {
                TerminalController.instance.Error(string.Format("Could not find command: {0}", commandName));
            }
        }
    }
}