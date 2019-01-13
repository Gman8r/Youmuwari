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
        gameController = GameObject.Find("Levels").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision");
        if (!fired && collision.gameObject == player)
        {
            gameController.StartTriggered();
        }
    }
}
