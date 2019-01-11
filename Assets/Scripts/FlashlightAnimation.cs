using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightAnimation : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private float spriteChangeTime;
    
    public Vector2 scaleRange;

    Vector3 initialScale;
    SpriteMask spriteMask;
    float spriteChangeTimer;

    void Start ()
    {
        spriteMask = GetComponent<SpriteMask>();
        spriteChangeTimer = spriteChangeTime;
        initialScale = transform.localScale;
        UpdateMaskSprite();
    }
	
	void Update ()
    {
        spriteChangeTimer -= Time.deltaTime;
        if (spriteChangeTimer <= 0f)
        {
            UpdateMaskSprite();
            spriteChangeTimer += spriteChangeTime;
        }
	}

    void UpdateMaskSprite()
    {
        spriteMask.sprite = sprites[Random.Range(0, sprites.Length)];
        spriteMask.transform.localScale = initialScale * MathHelper.randomRangeFromVector(scaleRange);
    }
}
