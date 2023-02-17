using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private CanvasGroup scoreCanvas;
    
    public RootController root;
    public float collideCounter = 0.0f;

    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
           case "Danger":
                Debug.Log("Danger");
                collideCounter++;
                
                FadeScript.instance.showUI();
                scoreCanvas.alpha = 0;
                StartCoroutine(WaitForFadeOut());

                break;
            case "Water":
                root.boost = true;
                break;
            default:
                root.boost = false;
                break;
        }
    }

    IEnumerator WaitForFadeOut()
    {
        while (FadeScript.instance.fadeIn)
        {
            yield return null;
        }

        while (true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                break;
            }
            yield return null;
        }

        SceneManager.LoadScene(1);
    }




}