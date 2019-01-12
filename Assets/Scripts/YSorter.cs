using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YSorter : MonoBehaviour
{
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        sprite.sortingOrder = -(int)Math.Round(transform.position.y * 10);
        Debug.Log(-(int)Math.Round(transform.position.y * 10));
    }
}
