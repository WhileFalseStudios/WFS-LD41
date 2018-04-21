using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public const int MAX_LOCK_LEVEL = 3;

    public static PlayerStats instance { get; private set; }

    public int bankBalance { get; private set; }

	//Manual Codes - must use buy to unlock
	//alphaManual automatically one, no checks done. 
	public bool alphaManual { get; set; }
	public bool betaManual { get; set; }
	public bool charlieManual { get; set; }
	public bool deltaManual { get; set; }

    public List<ShopController.ShopItem> unlockedItems { get; private set; }

    public List<string> lastGeneratedIPSet { get; set; }

    public Computer connectedComputer { get; set; }

    public int GetHighestLockLevel()
    {
        if (deltaManual) return 3;
        else if (charlieManual) return 2;
        else if (betaManual) return 1;
        else return 0;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            unlockedItems = new List<ShopController.ShopItem>();
        }
        else
        {
            Debug.LogWarning("Multiple PlayerStats instances exist!");
        }
    }

    public void AddBalance(int amount)
    {
        bankBalance += amount;
    }

	public void RemoveBalance(int amount)
	{
		bankBalance -= amount;
	}
}
