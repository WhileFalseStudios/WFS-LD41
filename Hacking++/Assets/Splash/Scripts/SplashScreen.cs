using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] BossSpinner fanSpinner;
    [SerializeField] Text logoText;

    [SerializeField] float fanSpinMaxSpeed;
    [SerializeField] float fanSpinupTime;
    [SerializeField] Ease fanSpinupEase;

    [SerializeField] float textFadeInTime;
    [SerializeField] Ease textFadeInEase;

    [SerializeField] float minimumHoldTime;

    AsyncOperation loadOp;

    void Start()
    {
        loadOp = SceneManager.LoadSceneAsync("Terminal", LoadSceneMode.Single);
        loadOp.allowSceneActivation = false;
        logoText.color = new Color(1, 1, 1, 0);
        DOTween.To(() => fanSpinner.rotationSpeed, x => fanSpinner.rotationSpeed = x, fanSpinMaxSpeed, fanSpinupTime).SetEase(fanSpinupEase).OnComplete(SpinUpDone);
    }

    void SpinUpDone()
    {
        logoText.DOColor(Color.white, textFadeInTime).SetEase(textFadeInEase).OnComplete(FadeInDone);
    }

    void FadeInDone()
    {
        DOTween.To(() => fanSpinner.rotationSpeed, x => fanSpinner.rotationSpeed = x, 0, fanSpinupTime).SetEase(fanSpinupEase).OnComplete(CompletelyDone);
    }

    void CompletelyDone()
    {
        StartCoroutine(CompletelyDoneDelay());
    }

    IEnumerator CompletelyDoneDelay()
    {
        yield return new WaitForSeconds(minimumHoldTime);

        while (loadOp.progress < 0.9f)
        {
            yield return null;
        }

        loadOp.allowSceneActivation = true;
    }
}
