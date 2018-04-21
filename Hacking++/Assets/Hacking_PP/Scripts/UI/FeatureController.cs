using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureController : MonoBehaviour
{
    public enum Feature
    {
        HackerManual,
        Wallpaper,
        MouseCursor,
    }

    [Header("Feature: Hacker Manual")]
    [SerializeField] private GameObject hackerManual;
    [Header("Feature: Wallpaper")]
    [SerializeField] private GameObject wallpaper;
    [Header("Feature: Mouse Cursor")]
    [SerializeField] private GameObject cursor;

    private void Awake()
    {
        hackerManual.SetActive(false);
        wallpaper.SetActive(false);
        cursor.SetActive(false);
    }

    public void UnlockFeature(Feature f)
    {
        switch (f)
        {
            case Feature.HackerManual:
                hackerManual.SetActive(true);
                break;
            case Feature.Wallpaper:
                wallpaper.SetActive(true);
                break;
            case Feature.MouseCursor:
                cursor.SetActive(true);
                break;
        }
    }
}
