using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Food : MonoBehaviour
{
    public BoxCollider gridArea;

    private void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);

        this.transform.position = new Vector3(Mathf.Round(x), 2.0f,Mathf.Round(z));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Console.Write("food catched");
            RandomizePosition();
            
            ScoreWindow.instance.AddCards();
            // GM.instance.drawCard();
        }
        
    }
}
