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
	public int echoPassOne;
	public int echoPassTwo;

	//lock tries
	public int deltaAttempts = 6;

    public Computer(string ip)
    {
        computerIP = ip;
        if (PlayerStats.instance != null)
        {
			int minimumLock = 1;
			if (PlayerStats.instance.GetHighestLockLevel () > 1) {
				minimumLock = PlayerStats.instance.GetHighestLockLevel () - 1;
			}
			lockType = Mathf.Clamp(Random.Range(minimumLock, PlayerStats.instance.GetHighestLockLevel() + 2), 0, PlayerStats.MAX_LOCK_LEVEL);
			hackBalance = Mathf.RoundToInt(Random.Range ((float)System.Math.Pow(10,lockType-1), (float)(System.Math.Pow (10, lockType) / 2)));
			unlockStatus = false;
			isLockedOut = false;
			playerTries = 0;

			//stores lock type to make sure no uber high level dupes.
			PlayerStats.instance.previousLockType = lockType;
			if (lockType == PlayerStats.instance.previousLockType && lockType == PlayerStats.instance.GetHighestLockLevel ()) {
				lockType--;
			}

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
			if (lockType == 5) {
				//0 - 99 fibonacci number
				int[] fibonacci = new [] {1,2,3,5,8,13,21,34,55,89};
				//0 - 9 array
				echoPassOne = Random.Range(0, 10);
				echoPassTwo = fibonacci [echoPassOne];
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