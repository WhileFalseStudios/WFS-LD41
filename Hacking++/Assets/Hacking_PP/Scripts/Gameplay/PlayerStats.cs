using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public const int MAX_LOCK_LEVEL = 4;

    public static PlayerStats instance { get; private set; }

    public int bankBalance { get; private set; }

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
