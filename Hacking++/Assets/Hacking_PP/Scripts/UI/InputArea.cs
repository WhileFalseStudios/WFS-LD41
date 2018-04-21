using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class InputArea : MonoBehaviour
{
    Text inputText;
    StringBuilder inputBuffer = new StringBuilder();

    private void Awake()
    {
        inputText = GetComponent<Text>();
        inputText.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
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

            inputText.text = inputBuffer.ToString() + "|";
        }
    }

    void RunCommand()
    {
        var cmd = inputBuffer.ToString();
        inputBuffer.Remove(0, inputBuffer.Length);
        if (TerminalController.instance != null)
        {
            TerminalController.instance.Print(cmd);
        }
    }
}
