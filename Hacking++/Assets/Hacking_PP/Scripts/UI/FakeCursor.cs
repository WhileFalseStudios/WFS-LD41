using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeCursor : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mPos = Input.mousePosition;
        ((RectTransform)transform).anchoredPosition = mPos;
    }
}
