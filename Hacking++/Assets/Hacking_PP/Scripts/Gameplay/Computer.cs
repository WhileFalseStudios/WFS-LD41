using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using UnityEngine;
using System;

public class Computer
{
    public string computerIP { get; private set; }
    public int lockType;
	public int hackBalance;
	public bool unlockStatus;

    public Computer(string ip)
    {
        computerIP = ip;
        if (PlayerStats.instance != null)
        {
            lockType = Mathf.Clamp(Random.Range(1, PlayerStats.instance.GetHighestLockLevel() + 2), 0, PlayerStats.MAX_LOCK_LEVEL);
			hackBalance = Random.Range (Math.Pow(10,lockType-1), Math.Pow(10, lockType)/2);
			unlockStatus = false;
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