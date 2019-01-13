using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{

    public bool fired = false;
    GameObject player;
    GameController gameController;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Youmu");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (!fired && collision.gameObject == player)
        {
            gameController.StartTriggered();
        }
    }
}
