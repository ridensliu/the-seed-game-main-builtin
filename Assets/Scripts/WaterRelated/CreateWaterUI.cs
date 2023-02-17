using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWaterUI : MonoBehaviour
{
    public static CreateWaterUI instance;
    
    public GameObject waterUiPrefab;
    public int cardNumber = 1;
    private RectTransform dropContainer;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        dropContainer = GameObject.Find("WaterDropContainer").GetComponent<RectTransform>();
        AddNewWaterUI();
    }

    // Update is called once per frame
    void Update()
    {
        // cardNumber = ScoreWindow.instance.cardNum;

        // if (Input.GetKeyDown(KeyCode.C))
        // {
        //     cardNumber++;
        //     AddNewWaterUI();
        // }

        // if (Input.GetKeyDown(KeyCode.X))
        // {
        //
        // }
        //
        // if (ScoreWindow.instance.cardNum - 1 > cardNumber)
        // {
        //     AddNewWaterUI();
        // }
    }

    public void AddNewWaterUI()
    {
        cardNumber++;
        GameObject newWaterDrop = Instantiate(waterUiPrefab, transform);
        // Debug.Log("new drop generated");
        newWaterDrop.transform.SetParent(dropContainer);
        
        RectTransform rectTransform = newWaterDrop.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3((cardNumber) * rectTransform.rect.width, 0, 0);
    }

    public void DeleteWaterUI()
    {
        if (cardNumber > 0)
        {
            cardNumber--;
        }
        int childCount = dropContainer.childCount;
        if (childCount > 0)
        {
            Destroy(dropContainer.GetChild(childCount -1).gameObject);
        }
    }
}
