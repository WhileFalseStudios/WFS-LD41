using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public const int MAX_LOCK_LEVEL = 5;

    public static PlayerStats instance { get; private set; }

    public int bankBalance { get; private set; }

	//Stores the previous lock generated to prevent too many dupes.
	public int previousLockType = 0;

	//Manual Codes - must use buy to unlock
	//alphaManual automatically one, no checks done. 
	public bool alphaManual
    {
        get
        {
            return unlockedItems.Contains(ShopController.ShopItem.AlphaLock);
        }
    }
	public bool betaManual
    {
        get
        {
            return unlockedItems.Contains(ShopController.ShopItem.BetaLock);
        }
    }
    public bool charlieManual
    {
        get
        {
            return unlockedItems.Contains(ShopController.ShopItem.CharlieLock);
        }
    }
	public bool deltaManual
	{
		get
		{
			return unlockedItems.Contains(ShopController.ShopItem.DeltaLock);
		}
	}
	public bool echoManual
	{
		get
		{
			return unlockedItems.Contains(ShopController.ShopItem.EchoLock);
		}
	}

    public bool GetHasLockLevel(int lockLevel)
    {
        switch (lockLevel)
        {
            case 0:
                return alphaManual;
            case 1:
                return betaManual;
            case 2:
                return charlieManual;
            case 3:
                return deltaManual;
			case 4:
				return echoManual;
            default:
                return false;
        }
    }

    public List<ShopController.ShopItem> unlockedItems { get; private set; }

    public List<string> lastGeneratedIPSet { get; set; }

    public Dictionary<string, AutoScript> userScripts { get; private set; }

    public Computer connectedComputer { get; set; }

    public int GetHighestLockLevel()
    {
		if (echoManual) return 5;
        if (deltaManual) return 4;
        else if (charlieManual) return 3;
        else if (betaManual) return 2;
        else return 1;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            unlockedItems = new List<ShopController.ShopItem>();
            userScripts = new Dictionary<string, AutoScript>();
            unlockedItems.Add(ShopController.ShopItem.AlphaLock);
        }
        else
        {
            Debug.LogWarning("Multiple PlayerStats instances exist!");
        }
    }

    public void AddBalance(int amount)
    {
        try
        {
            bankBalance += amount;
        }
        catch (System.OverflowException)
        {
            bankBalance = int.MaxValue;
        }
    }

	public void RemoveBalance(int amount)
	{
        try
        {
            bankBalance -= amount;
        }
        catch (System.OverflowException)
        {
            bankBalance = int.MinValue;
        }
	}
}
