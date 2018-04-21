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
	public bool unlockStatus;
	public int playerTries;
	public bool isLockedOut;

	//lock passwords
	public int charliePass;
	public int deltaPass;

	//lock tries
	public int deltaAttempts = 6;

    public Computer(string ip)
    {
        computerIP = ip;
        if (PlayerStats.instance != null)
        {
            lockType = Mathf.Clamp(Random.Range(1, PlayerStats.instance.GetHighestLockLevel() + 2), 0, PlayerStats.MAX_LOCK_LEVEL);
			hackBalance = Mathf.RoundToInt(Random.Range ((float)System.Math.Pow(10,lockType-1), (float)(System.Math.Pow (10, lockType) / 2)));
			unlockStatus = false;
			isLockedOut = false;
			playerTries = 0;

			if (lockType == 3) {
				//0 - 9 randomised
				charliePass = Random.Range (0, 10);
			}
			if (lockType == 4) {
				//0 - 99 fibonacci number
				int[] fibonacci = new [] {1,2,3,5,8,13,21,34,55,89};
				//0 - 9 array
				deltaPass = Random.Range(0, 10);
				deltaPass = fibonacci [deltaPass];
			}
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