﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using UnityEngine;

public class Computer
{
    public string computerIP { get; private set; }
    public int lockType = 1;
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
	public int deltaAttempts = 10;

    public Computer(string ip)
    {
        computerIP = ip;
        if (PlayerStats.instance != null)
        {
			int minimumLock = 1;
			if (PlayerStats.instance.GetHighestLockLevel () > 2) {
				minimumLock = PlayerStats.instance.GetHighestLockLevel () - 1;
			}
			int maximumLock = PlayerStats.instance.GetHighestLockLevel () + 1;
			if (maximumLock > PlayerStats.MAX_LOCK_LEVEL){
				maximumLock = PlayerStats.MAX_LOCK_LEVEL;
			}
			lockType = Random.Range(minimumLock, maximumLock + 1);
			if (lockType == maximumLock && lockType != PlayerStats.instance.GetHighestLockLevel()){
				if (Random.Range(0, 4) == 0){
					lockType++;
				}
			}
			if (lockType == 0) {
				lockType = 1;
			}
			if (lockType > maximumLock) {
				lockType = maximumLock;
			}
			hackBalance = Mathf.RoundToInt(Random.Range ((float)System.Math.Pow(10,lockType-1), (float)(System.Math.Pow (10, lockType) / 2)));
			unlockStatus = false;
			isLockedOut = false;
			playerTries = 0;

			//stores lock type to make sure no uber high level dupes.
			PlayerStats.instance.previousLockType = lockType;
			/*if (lockType == PlayerStats.instance.previousLockType && lockType == PlayerStats.instance.GetHighestLockLevel ()) {
				if (lockType == 1) {
					lockType++;
				} else {
					lockType--;
				}
			}*/

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