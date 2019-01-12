using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private PointFollow pointFollow;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        pointFollow = GetComponent<PointFollow>();
        pointFollow.ProvideTarget = () => Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
