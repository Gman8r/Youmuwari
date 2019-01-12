using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public float tickDelay = 1f;

    Queue<Vector3> locationQueue;
    Camera mainCam;

    public Provider<Vector3> ProvidePosition { get; set; }

    void Start()
    {
        locationQueue = new Queue<Vector3>();
        mainCam = Camera.main;
        if (ProvidePosition == null)
            ProvidePosition = () => mainCam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        if (locationQueue.Count >= tickDelay && locationQueue.Count > 0)
            transform.position = locationQueue.Dequeue();
        locationQueue.Enqueue(ProvidePosition());
    }
}
