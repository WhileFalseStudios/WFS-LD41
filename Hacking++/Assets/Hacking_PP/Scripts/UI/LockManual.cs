using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockManual : MonoBehaviour
{
    [SerializeField] Text textBody;
    [SerializeField] Text textHeader;
    [SerializeField] Button nextButton;
    [SerializeField] Button previousButton;

    int currentLock = 0;

    private void OnEnable()
    {
        nextButton.onClick.AddListener(NextManual);
        previousButton.onClick.AddListener(PrevManual);
        SetManual();
    }
    
    private void OnDisable()
    {
        nextButton.onClick.RemoveListener(NextManual);
        previousButton.onClick.RemoveListener(PrevManual);
    }

    void SetManual()
    {        
        if (currentLock == PlayerStats.MAX_LOCK_LEVEL) nextButton.interactable = false;
        else nextButton.interactable = true;
        if (currentLock == 0) previousButton.interactable = false;
        else previousButton.interactable = true;

        if (PlayerStats.instance != null)
        {
            textHeader.text = ManualCommand.GetLockManualTitle(currentLock);

            if (PlayerStats.instance.GetHasLockLevel(currentLock))
            {                
                textBody.text = ManualCommand.GetLockManualDescription(currentLock);
            }
            else
            {
                textBody.text = "You do not own this manual. Please purchase it in order to view.";
            }
        }
    }

    public void NextManual()
    {
        currentLock = Mathf.Clamp(currentLock + 1, 0, PlayerStats.MAX_LOCK_LEVEL);
        SetManual();
    }

    public void PrevManual()
    {
        currentLock = Mathf.Clamp(currentLock - 1, 0, PlayerStats.MAX_LOCK_LEVEL);
        SetManual();
    }
}
