using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public enum ShopItem
    {
        AlphaLock,
        BetaLock,
        CharlieLock,
        SystemTime,
        LockManual,
        Wallpaper,
        Cursor,
    }

    public enum BuyCode
    {
        OK,
        TooExpensive,
        AlreadyOwns,
    }

    public struct Item
    {
        public string name;
        public int cost;
    }

    public static ShopController instance { get; private set; }

    public Dictionary<ShopItem, Item> itemNameTable { get; private set; }

    private void Awake()
    {
        itemNameTable = new Dictionary<ShopItem, Item>();

        itemNameTable.Add(ShopItem.BetaLock, new Item { name = "Beta Lock", cost = 100 });
        itemNameTable.Add(ShopItem.CharlieLock, new Item { name = "Charlie Lock", cost = 1000 });
        itemNameTable.Add(ShopItem.SystemTime, new Item { name = "System Time", cost = 30 });
        itemNameTable.Add(ShopItem.LockManual, new Item { name = "Lock Manual", cost = 200 });
        itemNameTable.Add(ShopItem.Wallpaper, new Item { name = "Wallpaper", cost = 20 });
        itemNameTable.Add(ShopItem.Cursor, new Item { name = "Mouse Cursor", cost = 45 });

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple shop controllers exist!");
        }
    }

    public BuyCode BuyItem(ShopItem item)
    {
        if (PlayerStats.instance != null)
        {
            if (itemNameTable.ContainsKey(item))
            {
                if (PlayerStats.instance.unlockedItems.Contains(item)) return BuyCode.AlreadyOwns;

                if (PlayerStats.instance.bankBalance - itemNameTable[item].cost > 0)
                {
                    PlayerStats.instance.RemoveBalance(itemNameTable[item].cost);
                    PlayerStats.instance.unlockedItems.Add(item);
                    if (FeatureController.instance != null)
                    {
                        switch (item)
                        {
                            case ShopItem.SystemTime:
                                FeatureController.instance.UnlockFeature(FeatureController.Feature.SystemClock);
                                break;
                            case ShopItem.Wallpaper:
                                FeatureController.instance.UnlockFeature(FeatureController.Feature.Wallpaper);
                                break;
                            case ShopItem.LockManual:
                                FeatureController.instance.UnlockFeature(FeatureController.Feature.HackerManual);
                                break;
                            case ShopItem.Cursor:
                                FeatureController.instance.UnlockFeature(FeatureController.Feature.MouseCursor);
                                break;
                        }
                    }
                    return BuyCode.OK;
                }
            }
        }

        return BuyCode.TooExpensive;
    }
}
