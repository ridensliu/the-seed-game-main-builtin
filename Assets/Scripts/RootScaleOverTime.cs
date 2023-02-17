using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootScaleOverTime : MonoBehaviour
{
    //private bool shouldScale;
    public Vector3 startScaleSize;
    public Vector3 endScaleSize;
    private float percentageComplete;

    void Start()
    {
       
    }

   
    void Update()
    {
        percentageComplete += Time.deltaTime * 0.1f;
        transform.localScale = Vector3.Lerp(startScaleSize, endScaleSize, percentageComplete);
    }

   
}
