using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    [SerializeField]
    public float Speed = 1f;

    private Rigidbody2D rigidBody;
    private PointFollow pointFollow;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        pointFollow.ProvideTarget = () =>
        {
            var cam = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return new Vector2(cam.x, cam.y) - rigidBody.position;
        };
    }
}
