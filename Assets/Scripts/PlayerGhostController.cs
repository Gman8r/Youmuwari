using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhostController : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        var go = GameObject.Find("Darkness Layers");
        var list = go.GetComponentsInChildren<Flashlight>();
        foreach (var flashlight in list)
            flashlight.ProvidePosition = () => rigidBody.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
