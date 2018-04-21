using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using UnityEngine;

public class Computer
{
    public string computerIP { get; private set; }
    public int lockType;
	public int hackBalance;

    public Computer(string ip)
    {
        computerIP = ip;
        if (PlayerStats.instance != null)
        {
            lockType = Mathf.Clamp(Random.Range(0, PlayerStats.instance.GetHighestLockLevel() + 1), 0, PlayerStats.MAX_LOCK_LEVEL);
			hackBalance = Random.Range ((lockType - 1 * 10), (lockType * 10));
        }

#if UNITY_EDITOR
        Debug.LogFormat("Computer generated! Locktype: {0}", lockType);
#endif
    }

    public bool TrySolve(string solution)
    {
        return false;
    }
}