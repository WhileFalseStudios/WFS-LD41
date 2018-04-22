using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScriptEditor : MonoBehaviour
{
    public static ScriptEditor instance { get; private set; }

    [SerializeField] InputField scriptInput;
    [SerializeField] Button saveButton;
    [SerializeField] Button closeButton;
    [SerializeField] Text scriptHeader;

    AutoScript script;
    bool hasSaved = true;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void SetScript(AutoScript sc)
    {
        script = sc;
        scriptInput.text = script.code;
        UpdateHeader();
    }

    void OnEnable()
    {
        saveButton.onClick.AddListener(ScriptSave);
        closeButton.onClick.AddListener(ScriptClose);
        scriptInput.onValueChanged.AddListener(ScriptEdited);
    }

    void OnDisable()
    {
        saveButton.onClick.RemoveListener(ScriptSave);
        closeButton.onClick.RemoveListener(ScriptClose);
        scriptInput.onValueChanged.RemoveListener(ScriptEdited);
    }

    void ScriptSave()
    {
        if (script != null)
        {
            script.code = scriptInput.text;
            hasSaved = true;
            UpdateHeader();
        }
    }

    void ScriptEdited(string changes)
    {
        hasSaved = false;
        UpdateHeader();
    }

    void ScriptClose()
    {
        gameObject.SetActive(false);
    }

    void UpdateHeader()
    {
        if (script != null)
        {
            scriptHeader.text = string.Format("Script Editor: {0}{1}", script.name, hasSaved ? string.Empty : "*");
        }
    }   
}
