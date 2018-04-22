using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardSounds : MonoBehaviour
{
    [SerializeField] List<AudioClip> normalKeyboardSounds = new List<AudioClip>();
    [SerializeField] List<AudioClip> spacebarKeyboardSounds = new List<AudioClip>();
    [SerializeField] List<AudioClip> bigKeyKeyboardSounds = new List<AudioClip>();

    new AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode k in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(k))
                {
                    KeyPressed(k);
                }
            }
        }
    }

    public void KeyPressed(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.Space:
                PlaySpaceKey();
                break;
            case KeyCode.LeftShift:
            case KeyCode.RightShift:
            case KeyCode.Backspace:
            case KeyCode.Return:
            case KeyCode.Keypad0:
            case KeyCode.KeypadPlus:
            case KeyCode.KeypadEnter:
                PlayBigKey();
                break;
            default:
                PlayNormalKey();
                break;
        }
    }

    void PlayNormalKey()
    {
        audio.PlayOneShot(normalKeyboardSounds[Random.Range(0, normalKeyboardSounds.Count)]);
    }

    void PlaySpaceKey()
    {
        audio.PlayOneShot(spacebarKeyboardSounds[Random.Range(0, spacebarKeyboardSounds.Count)]);
    }

    void PlayBigKey()
    {
        audio.PlayOneShot(bigKeyKeyboardSounds[Random.Range(0, bigKeyKeyboardSounds.Count)]);
    }
}
