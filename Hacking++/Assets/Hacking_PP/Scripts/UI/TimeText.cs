using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        DateTime time = DateTime.Now;
        text.text = string.Format("{0}:{1} {2}", time.Hour, time.Minute.ToString("00"), time.ToShortDateString());
    }
}
