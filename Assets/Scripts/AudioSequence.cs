using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioSequence : MonoBehaviour
{
    [HideInInspector]
    public float depth;
    private float layer1fade;
    private float layer2fade;
    private float layer3fade;

    //private bool layer1IsPlaying;
    //private bool layer2IsPlaying;

    //public AudioManager manager;
    
    public AudioSource layer0;
    public AudioSource layer1;
    public AudioSource layer2;

    [SerializeField] private CanvasGroup scoreCanvas;
    void Start()
    {
        //layer1IsPlaying = false;
        //layer2IsPlaying = false;

        layer1fade = 0.0f;
        layer2fade = 0.0f;

    }

 
    void Update()
    {
        depth = transform.position.z;
        //Debug.Log(depth);
        // Debug.Log("Layer 1 volume is " + layer1.volume);

        if (depth < -25.0f)
        {
            layer1fade += Time.deltaTime * 0.1f;
            layer1.volume = Mathf.Lerp(0, 1, layer1fade);
        }

        if (depth < -50.0f)
        {
            layer2fade += Time.deltaTime * 0.1f;
            layer2.volume = Mathf.Lerp(0, 1, layer2fade);
        }

        if (depth < -80.0f)
        {
            // win 
            winCondition();
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    private void winCondition()
    {
        FadeScript.instance.showWinUI();
        scoreCanvas.alpha = 0;
        // StartCoroutine(WaitForRestart());
    }

    // IEnumerator WaitForRestart()
    // {
    //     while (FadeScript.instance.winFadeIn)
    //     {
    //         // Debug.Log("opening winning UI");
    //         yield return null;
    //     }
    //     
    //     
    //     while (true)
    //     {
    //         if (Input.GetKeyDown(KeyCode.R))
    //         {
    //             Debug.Log("win key pressed");
    //             break;
    //         }
    //
    //         yield return null;
    //     }
    //
    //     SceneManager.LoadScene(1);
    // }
}
