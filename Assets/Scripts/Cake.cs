using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    public Animator fadeAnimator;
    // Use this for initialization
    void Start()
    {
        fadeAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Dispose()
    {
        Destroy(gameObject, 0.2f);
    }
}
