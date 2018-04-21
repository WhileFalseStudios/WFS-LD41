using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance { get; private set; }

    public int bankBalance { get; private set; }

	//Manual Codes - must use buy to unlock
	//alphaManual automatically one, no checks done. 
	public bool alphaManual { get; set; }
	public bool betaManual { get; set; }
	public bool charlieManual { get; set; }
	public bool deltaManual { get; set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
