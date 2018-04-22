using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CRT : MonoBehaviour
{
    Material crtMat;
    [SerializeField] private Texture2D overlay;
    [SerializeField] private float coefficient = 0.3f;
    [SerializeField] private float cube = -0.15f;

    private void Awake()
    {
        crtMat = new Material(Shader.Find("Hidden/CRT Effect"));        
        SetShaderParms();
    }

    void SetShaderParms()
    {
        if (crtMat != null)
        {
            crtMat.SetFloat("_Cube", cube);
            crtMat.SetFloat("_Coefficient", coefficient);
            if (overlay != null)
            {
                crtMat.SetTexture("_ScreenOverlay", overlay);
            }
        }
    }

    private void Update()
    {
        if (Application.isEditor)
        {
            SetShaderParms();
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, crtMat);
    }
}
