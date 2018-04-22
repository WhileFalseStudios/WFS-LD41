using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallpaper : MonoBehaviour
{
    [SerializeField] private Sprite communismBackground;

    Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    public void Revolt()
    {
        img.sprite = communismBackground;
    }
}
