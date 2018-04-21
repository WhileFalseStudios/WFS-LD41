using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalController : MonoBehaviour
{
    public static TerminalController instance { get; private set; }

    const int MAX_BUFFER_COUNT = 35;
    Queue<string> messages = new Queue<string>();

    const string errorColour = "#ca861b";

    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
        text.text = string.Empty;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple terminal controllers exist! What the hell.");
        }
    }

    public void Print(string msg)
    {
        messages.Enqueue(msg);
        if (messages.Count > MAX_BUFFER_COUNT)
        {
            string rem = messages.Dequeue();
            text.text = text.text.Remove(0, rem.Length + 1); //+1 because of \n
        }

        text.text += "\n" + msg;
    }

    public void Error(string msg)
    {
        msg = string.Format("<color={0}>{1}</color>", errorColour, msg);
        messages.Enqueue(msg);
        if (messages.Count > MAX_BUFFER_COUNT)
        {
            string rem = messages.Dequeue();
            text.text = text.text.Remove(0, rem.Length + 1); //+1 because of \n
        }

        text.text += "\n" + msg;
    }
}
