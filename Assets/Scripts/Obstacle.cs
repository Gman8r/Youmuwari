using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    Collider2D coll;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        coll = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    public void Open()
    {
        coll.isTrigger = true;
        animator.SetTrigger("lulw");
    }

    public void Close()
    {
        coll.isTrigger = false;
        animator.SetTrigger("lulw");
    }
}
