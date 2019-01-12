using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    FollowerEnemy yuyu;
    PlayerMovement playerMovement;

    Obstacle entryObs;
    Obstacle exitObs;

    [SerializeField]
    public GameObject cakePrefab;

    void StartLevel()
    {
        CloseDoors();
        ActivateYuyu();
        SpawnCake();
    }

    // Use this for initialization
    void Start()
    {
        yuyu = GetComponentInChildren<FollowerEnemy>();
        playerMovement = GetComponentInChildren<PlayerMovement>();

        entryObs = transform.Find("Entry").gameObject.GetComponent<Obstacle>();
        exitObs = transform.Find("Exit").gameObject.GetComponent<Obstacle>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CloseDoors()
    {

    }

    void OpenDoors()
    {

    }

    void ActivateYuyu()
    {
        yuyu.gameObject.SetActive(true);
        yuyu.pointFollow.ProvideTarget = () => playerMovement.transform.position;
    }

    void SpawnCake()
    {
        var position = GameObject.Find("CakePositions");
        var go = Instantiate(cakePrefab, transform);

    }
}
