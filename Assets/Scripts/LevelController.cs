using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public float cakePrefDist = 2f;
    public float cakeDevourDist = 0.2f;
    public float yuyuAggroDist = 3f;
    public float yuyuDeathDist = 0.2f;

    FollowerEnemy yuyu;
    PlayerMovement playerMovement;

    Obstacle entryObs;
    Obstacle exitObs;

    //Nullable
    GameObject cake;

    [SerializeField]
    public GameObject cakePrefab;

    void StartLevel()
    {
        CloseDoors();
        ActivateYuyu();
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
        var yuyuToPlayerDist = (playerMovement.transform.position - yuyu.transform.position).magnitude;
        var yuyuToCakeDist = 100000f;
        if (cake != null)
            yuyuToCakeDist = (cake.transform.position - yuyu.transform.position).magnitude;

        if (yuyu.CurrentState == FollowerEnemy.State.IDLE)
        {
            //Yu is aggroed
            if (yuyuToPlayerDist < yuyuAggroDist)
            {
                yuyu.ResetState(FollowerEnemy.State.PLAYER);
                SpawnCake();

            }
        }
        else if (yuyu.CurrentState == FollowerEnemy.State.CAKE)
        {
            //Yu can eat
            if (yuyuToCakeDist < cakeDevourDist)
            {
                Debug.Log("NOMNO");
                exitObs.Open();
            }
        }
        else if (yuyu.CurrentState == FollowerEnemy.State.PLAYER)
        {
            //Yu prefers the cake
            if (yuyuToCakeDist < cakePrefDist)
            {
                yuyu.ResetState(FollowerEnemy.State.CAKE);
                return;
            }
            //Rip
            if (yuyuToPlayerDist < yuyuDeathDist)
            {
                Debug.Log("DETH");
            }
        }
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
        var go1 = GameObject.Find("CakePositions");
        var selectedIdx = UnityEngine.Random.Range(0, transform.childCount);
        var pos = transform.GetChild(selectedIdx).position;

        cake = Instantiate(cakePrefab, transform);
        cake.transform.position = pos;
    }
}
