using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveAcc;
    [SerializeField]
    private float maxMoveSpeed;
    [SerializeField]
    private float stopDec;
    [SerializeField]
    private float turnAroundMult;

    private Rigidbody2D rigidBoi;

    private Direction currentDirection;
    public enum Direction
    {
        Right,
        Up,
        Left,
        Down
    }

    void Start ()
    {
        rigidBoi = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        UpdateMovement();
	}

    void UpdateMovement()
    {
        var xInput = Input.GetAxisRaw("Horizontal");
        var yInput = Input.GetAxisRaw("Vertical");

        var frameAcc = new Vector2(xInput, yInput) * (moveAcc * Time.deltaTime);
        if (Mathf.Sign(xInput) == -Mathf.Sign(rigidBoi.velocity.x)
            || Mathf.Sign(yInput) == -Mathf.Sign(rigidBoi.velocity.y))
            frameAcc *= turnAroundMult;

        if (xInput != 0 || yInput != 0f)
        {
            rigidBoi.velocity += frameAcc;
            if (rigidBoi.velocity.magnitude > maxMoveSpeed)
                rigidBoi.velocity = rigidBoi.velocity.resize(maxMoveSpeed);
        }
        else
        {
            rigidBoi.velocity = Vector2.MoveTowards(rigidBoi.velocity, Vector2.zero, stopDec * Time.deltaTime);
        }
    }
}
