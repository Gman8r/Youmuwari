using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFollow : MonoBehaviour
{
    public float Force = 50f;
    public bool IsFollowing = true;
    public Provider<Vector2> ProvideTarget { get; set; }

    private Rigidbody2D rigidBody;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IsFollowing || ProvideTarget == null)
            return;
        var target = -rigidBody.position + ProvideTarget();
        var magnitude = target.magnitude;
        var magnitudeThreshold = Force * 0.1f;

        if (magnitude > magnitudeThreshold)
            rigidBody.AddForce(Force * target.normalized, ForceMode2D.Force);
        else if (target.magnitude > 0.01f)
            rigidBody.AddForce((magnitude / magnitudeThreshold) * Force * target.normalized, ForceMode2D.Force);
    }
}
