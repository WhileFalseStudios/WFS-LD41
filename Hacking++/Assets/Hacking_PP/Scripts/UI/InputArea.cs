using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class InputArea : MonoBehaviour
{
    Text inputText;
    StringBuilder inputBuffer = new StringBuilder();
    Queue<string> historyBuffer = new Queue<string>();
    int historyBufferPosition = 0;
    public const int MAX_HISTORY_BUFFER = 64;

    private void Awake()
    {
        inputText = GetComponent<Text>();
        inputText.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.instance != null && !PlayerStats.instance.isInEditor)
        {
            var input = Input.inputString;
            foreach (var c in input)
            {
                switch (c)
                {
                    case '\r': //Enter
                        RunCommand();
                        break;
                    case '\t': //Tab
                        break;
                    case '\b': //Backspace
                        if (inputBuffer.Length > 0) inputBuffer.Remove(inputBuffer.Length - 1, 1);
                        break;
                    default:
                        inputBuffer.Append(c);
                        break;
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                historyBufferPosition = Mathf.Clamp(historyBufferPosition + 1, 0, historyBuffer.Count);
                UpdateInputBufferFromHistory();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                historyBufferPosition = Mathf.Clamp(historyBufferPosition - 1, 0, historyBuffer.Count);
                UpdateInputBufferFromHistory();
            }

            inputText.text = inputBuffer.ToString() + "|";
        }
    }

    void UpdateInputBufferFromHistory()
    {
        var hb = historyBuffer.ToArray();        
        inputBuffer.Remove(0, inputBuffer.Length);
        int pos = (hb.Length) - historyBufferPosition;
        if (pos >= 0 && pos < hb.Length)
        {
            inputBuffer.Append(hb[pos]);
        }
    }

    void RunCommand()
    {
        historyBufferPosition = 0;
        var cmd = inputBuffer.ToString();
        inputBuffer.Remove(0, inputBuffer.Length);
        AddToHistoryBuffer(cmd);
        if (TerminalController.instance != null)
        {
            TerminalController.instance.Print("> " + cmd);
        }

        if (CommandInterpreter.instance != null)
        {
            CommandInterpreter.instance.InterpretCommand(cmd);
        }
    }

    void AddToHistoryBuffer(string cmd)
    {
        historyBuffer.Enqueue(cmd);
        if (historyBuffer.Count > MAX_HISTORY_BUFFER)
        {
            historyBuffer.Dequeue();
        }
    }
}
