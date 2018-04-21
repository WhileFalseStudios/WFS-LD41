﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureController : MonoBehaviour
{
    public enum Feature
    {
        HackerManual,
        Wallpaper,
        MouseCursor,
        SystemClock,
    }

    public static FeatureController instance { get; private set; }

    [Header("Feature: Hacker Manual")]
    [SerializeField] private GameObject hackerManual;
    [Header("Feature: Wallpaper")]
    [SerializeField] private GameObject wallpaper;
    [Header("Feature: Mouse Cursor")]
    [SerializeField] private GameObject cursor;
    [Header("Feature: System Clock")]
    [SerializeField] private GameObject systemClock;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            hackerManual.SetActive(false);
            wallpaper.SetActive(false);
            cursor.SetActive(false);
            systemClock.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Multiple feature controllers exist!");
        }
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
            case Feature.SystemClock:
                systemClock.SetActive(true);
                break;
        }
    }
}
