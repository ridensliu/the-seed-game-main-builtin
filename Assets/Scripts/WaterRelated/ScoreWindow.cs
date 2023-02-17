using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    public static ScoreWindow instance;
    // [SerializeField] private CanvasGroup scoreCanvas;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI cardText;
    public float WaterSpeed = 100.0f;
    
    public float score = 100;
    public int cardNum = 1;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = score.ToString();
        cardText.text = cardNum.ToString();
    }
    void Update()
    {
        if (cardNum > 0)
        {
            // count down water
            score -= WaterSpeed * Time.deltaTime;
            scoreText.text = Mathf.Round(Mathf.Max(score, 0)).ToString();
            
            // when have no water, discard the card
            if (Mathf.Round(Mathf.Max(score, 0)) == 0)
            {
                score = 0;
                cardNum -= 1;
                cardText.text = cardNum.ToString();
                if (cardNum > 0)
                {
                    resetPoints();
                }
                
                CreateWaterUI.instance.DeleteWaterUI();
            }
        }

        if (cardNum == 0)
        {
            FadeScript.instance.showUI();
            
            StartCoroutine(WaitForFadeOut());
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(1);
            }
            // transform.parent.gameObject.SetActive(false);
        }
        //press space to use card (gived up now)
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     cardUsed();
        // }
    
    }

    IEnumerator WaitForFadeOut()
    {
        while (FadeScript.instance.fadeIn)
        {
            yield return null;
        }
    }
    
    public void cardUsed()
    {
        score = 0;
        scoreText.text = score.ToString();
        if (cardNum > 0)
        {
            cardNum--;
            cardText.text = cardNum.ToString();
            if (cardNum > 0)
            {
                resetPoints();
            }
        }
    }

    private void resetPoints()
    {
        score = 100;
        scoreText.text = score.ToString();
    }

    public void AddCards()
    {
        cardNum += 1;
        cardText.text = cardNum.ToString();
        if (cardNum == 1)
        {
            resetPoints();
        }
        
        CreateWaterUI.instance.AddNewWaterUI();
    }
}
