using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance { get; private set; }

    public int bankBalance { get; private set; }

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

    void AddBalance(int amount)
    {
        bankBalance += amount;
    }
}
