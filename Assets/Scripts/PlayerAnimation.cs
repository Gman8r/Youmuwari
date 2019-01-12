using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private float frameSpeed;
    [SerializeField]
    private SpriteList[] movementSprites;
    [SerializeField]
    private Sprite[] idleSprites;
    [SerializeField]
    private SpritePriority diagonalPriority;

    private enum SpritePriority
    {
        Last,
        Vertical,
        Horizontal
    }


    SpriteRenderer spriteRenderer;
    PlayerMovement.Direction currentDirection;
    bool moving;
    float frameIndex;

    [System.Serializable]
    public class SpriteList
    {
        [SerializeField]
        private Sprite[] sprites;
        public Sprite[] GetSprites() { return sprites; }
    }

	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentDirection = PlayerMovement.Direction.Down;
        moving = false;
	}
	
	void Update ()
    {
        var xInput = Input.GetAxisRaw("Horizontal");
        var yInput = Input.GetAxisRaw("Vertical");

        moving = xInput != 0f || yInput != 0f;
        if (moving)
        {
            var inputVector = new Vector2(xInput, yInput);
            var movementAngle = MathHelper.trueMod(inputVector.getAngle(), 360f);
            var calculationAngle = MathHelper.trueMod(movementAngle + 45f, 360f); // Used to split movement into 4 quadrants

            if (calculationAngle % 90f == 0f   // If right on the cusp of two directions, keep current direction
                && Mathf.Abs(Mathf.DeltaAngle(movementAngle, (float)currentDirection * 90f)) <= 91f) // Unless we've turned too much
            {
                if (diagonalPriority == SpritePriority.Vertical)
                    currentDirection = movementAngle < 180f ? PlayerMovement.Direction.Up : PlayerMovement.Direction.Down;
                else if (diagonalPriority == SpritePriority.Horizontal)
                    currentDirection = (movementAngle > 90f && movementAngle < 270f) ? PlayerMovement.Direction.Up : PlayerMovement.Direction.Down;
            }
            else
            {
                currentDirection = (PlayerMovement.Direction)(((int)calculationAngle) / 90);
            }

            transform.localScale = new Vector3(
                Mathf.Abs(transform.localScale.x) * (currentDirection == PlayerMovement.Direction.Right ? -1f : 1f),
                transform.localScale.y,
                transform.localScale.z);

            var spriteSet = movementSprites[(int)currentDirection].GetSprites();
            frameIndex += frameSpeed * Time.deltaTime;
            while (frameIndex >= spriteSet.Length)
                frameIndex -= spriteSet.Length;
            spriteRenderer.sprite = spriteSet[Mathf.FloorToInt(frameIndex)];
        }
        else
        {
            spriteRenderer.sprite = idleSprites[(int)currentDirection];
        }

    }
}
