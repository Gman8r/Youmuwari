using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFollow : MonoBehaviour
{
    public float Force = 50f;
    public float MagnitudeThreshold = 0.5f;
    public bool IsFollowing { get; set; }
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
        var target = ProvideTarget();

        if (target.magnitude > MagnitudeThreshold)
            rigidBody.AddForce(Force * target.normalized, ForceMode2D.Force);
    }
}
