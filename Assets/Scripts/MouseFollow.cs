using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    /*private Rigidbody2D rigidBody;
    private PointFollow pointFollow;*/

    public void Disable()
    {
        //pointFollow.ProvideTarget = null;
    }
    public void Enable()
    {
        //pointFollow.ProvideTarget = () => Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Use this for initialization
    void Start()
    {
    }

    void Update()
    {
        var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (transform.position != targetPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, 100f * Time.deltaTime);
        }
    }

}
