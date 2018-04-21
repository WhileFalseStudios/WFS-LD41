using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureController : MonoBehaviour
{
    public enum Feature
    {
        HackerManual
    }

    [Header("Feature: Hacker Manual")]
    [SerializeField] private GameObject hackerManual;

    private void Awake()
    {
        hackerManual.SetActive(false);
    }

    public void UnlockFeature(Feature f)
    {
        switch (f)
        {
            case Feature.HackerManual:
                hackerManual.SetActive(true);
                break;
        }
    }
}
