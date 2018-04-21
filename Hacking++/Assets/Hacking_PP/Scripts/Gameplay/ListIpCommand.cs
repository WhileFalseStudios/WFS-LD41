using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ListIpCommand : Command
{
    const int IP_GEN_COUNT = 5;

    public ListIpCommand(CommandInterpreter i) : base(i) { }


    public override string GetHelpString()
    {
        return "Generate a list of ip addresses that can be connected to.";
    }

    public override void Execute(params string[] args)
    {
        List<string> ips = new List<string>();

        Print(string.Format("Found {0} IP addresses:", IP_GEN_COUNT));

        for (int i = 0; i < IP_GEN_COUNT; i++)
        {
            byte[] ip = new byte[4];
            for (int j = 0; j < 4; j++)
            {
                ip[j] = (byte)Random.Range(0, 255);
            }
            string iii = string.Format("{0}.{1}.{2}.{3}", ip[0], ip[1], ip[2], ip[3]);
            ips.Add(iii);
            Print(iii);
        }

        if (PlayerStats.instance != null)
        {
            PlayerStats.instance.lastGeneratedIPSet = ips;
        }

        Print("Use the 'connect' command to connect to a computer.");
    }
}