using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
    public static RootController instance;
    Vector3 pos;
    public float speed = 0.01f;
    float angle;
    public float RootSpeed;
    public bool boost = false;

    // References
    public GameObject BodyPrefab;

    // Lists
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        FollowMouse();
        RotateRoot();

        if(Input.GetKeyDown("space")){
            SlowDown();
        }

        // Bugfix 
        if (BodyParts.Count > 1) {
            Destroy(BodyParts[0]);
        }
    }

    void GrowRoot(){
            GameObject body = Instantiate(BodyPrefab);
            Vector3 point = PositionsHistory[0];
            body.transform.position = transform.position;
            BodyParts.Add(body);
    }

    void FollowMouse()
    {
        pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        if (boost) 
        { 
            SpeedUp();
        } 

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(pos.x, 0.0f, pos.z), speed * Time.deltaTime);

        
        // Store position history
        PositionsHistory.Insert(0, transform.position);

        if (PositionsHistory.Count > 1) {
            if (PositionsHistory[0] != PositionsHistory[1]){
                GrowRoot();
            }
        }
    }

    void RotateRoot()
    {
        angle += Input.GetAxis("Mouse X") * RootSpeed * -Time.deltaTime;
        angle = Mathf.Clamp(angle, -90, 270);
        transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
    }

    void SpeedUp()
    {
        if(speed < 4){ //maxspeed
            speed = speed + 0.5f;
        }
    }

    void SlowDown()
    {
        if(speed > 0)
        {
            speed = speed - 1;
        }
    }

}
