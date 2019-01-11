using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public float tickDelay = 1f;
    
    Queue<Vector3> locationQueue;
    Camera mainCam;
    
	void Start ()
    {
        locationQueue = new Queue<Vector3>();
        mainCam = Camera.main;
	}
	
	void FixedUpdate ()
    {
        if (locationQueue.Count >= tickDelay && locationQueue.Count > 0)
            transform.position = locationQueue.Dequeue();
        locationQueue.Enqueue(mainCam.ScreenToWorldPoint(Input.mousePosition));
	}
}
