using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{
    public static FadeScript instance;
    
    [SerializeField] private CanvasGroup myUIGroup;
    [SerializeField] private CanvasGroup winUIGroup;

    public bool fadeIn = false;
    
    public bool fadeOut = false;

    public bool winFadeIn = false;
    private void Awake()
    {
        instance = this;
    }

    public void showUI()
    {
        fadeIn = true;
    }

    public void showWinUI()
    {
        winFadeIn = true;
    }
    
    public void hideUI()
    {
        fadeOut = true;
    }

    private void Update()
    {
        if (fadeIn)
        {
            if (myUIGroup.alpha < 1)
            {
                myUIGroup.alpha += Time.deltaTime;
                if (myUIGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }
        
        if (winFadeIn)
        {
            if (winUIGroup.alpha < 1)
            {
                winUIGroup.alpha += Time.deltaTime;
                if (winUIGroup.alpha >= 1)
                {
                    winFadeIn = false;
                }
            }
        }

        if (fadeOut)
        {
            if (myUIGroup.alpha >= 0)
            {
                myUIGroup.alpha -= Time.deltaTime;
                if (myUIGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }
}
