using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothspeed = 0.12f;
    public Vector3 offset;

    public Transform endMarker = null; // create an empty gameobject and assign in inspector
    public bool endGame = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(endGame){
            transform.position = Vector3.Lerp(transform.position, endMarker.position, Time.deltaTime);
        } else {
            Vector3 desiredPost = target.position + offset;
            Vector3 smoothPost = Vector3.Lerp(transform.position, desiredPost, smoothspeed);
            transform.position = smoothPost;    
        }
        if(Input.GetKeyDown("x")){
            endGame = true;
        }       
    }
}
