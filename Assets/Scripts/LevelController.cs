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

    public bool won;
    public bool lost;
    public bool started;

    FollowerEnemy yuyu;
    PlayerMovement playerMovement;

    Obstacle entryObs;
    Obstacle exitObs;

    //Nullable
    GameObject cake;

    GameController gameController;

    [SerializeField]
    public GameObject cakePrefab;

    AudioSource titleMusic;
    AudioSource gameMusic;

    void StartLevel()
    {

    }

    // Use this for initialization
    void Start()
    {
        yuyu = GetComponentInChildren<FollowerEnemy>();
        playerMovement = GameObject.Find("Youmu").GetComponentInChildren<PlayerMovement>();
        gameController = GameObject.Find("Levels").GetComponent<GameController>();

        entryObs = transform.Find("Entry").gameObject.GetComponent<Obstacle>();
        exitObs = transform.Find("Exit").gameObject.GetComponent<Obstacle>();

        titleMusic = GameObject.Find("TitleMusic").GetComponent<AudioSource>();
        gameMusic = GameObject.Find("GameMusic").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!started) return;
        if (won || lost) return;

        var yuyuToPlayerDist = (playerMovement.transform.position - yuyu.transform.position).magnitude;
        var yuyuToCakeDist = 100000f;
        if (cake != null)
            yuyuToCakeDist = (cake.transform.position - yuyu.transform.position).magnitude;

        if (yuyu.CurrentState == FollowerEnemy.State.IDLE)
        {
            //Yu is aggroed
            if (yuyuToPlayerDist < yuyuAggroDist)
            {
                if (!switchedMusic)
                {
                    yuyu.GetComponent<AudioSource>().Play();
                    if (gameController.currentLevel == 1)
                    {
                        switchedMusic = true;
                        FadeOut(titleMusic, 1f);
                        playGameMusic();
                    }
                }
                yuyu.ResetState(FollowerEnemy.State.PLAYER);
                SpawnCake();
                CloseDoors();
            }
        }
        else if (yuyu.CurrentState == FollowerEnemy.State.CAKE)
        {
            //Yu can eat
            if (yuyuToCakeDist < cakeDevourDist)
            {
                won = true;
                Debug.Log("NOMNO");
                exitObs.Open();
                yuyu.animator.SetTrigger("reverse");
                GameObject.Destroy(yuyu.gameObject, 4f);
                cake.GetComponent<Cake>().fadeAnimator.SetTrigger("lulw");
                GameObject.Destroy(cake.gameObject, 4f);
                gameController.CompleteLevel();
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
                lost = true;
                Debug.Log("DETH");
            }
        }
    }
    bool switchedMusic = false;
    void CloseDoors()
    {
        entryObs.Close();
        exitObs.Close();
    }

    void OpenDoors()
    {

    }

    void SpawnCake()
    {
        var go1 = transform.Find("CakePositions");
        var selectedIdx = UnityEngine.Random.Range(0, go1.transform.childCount);

        cake = Instantiate(cakePrefab, go1.transform.GetChild(selectedIdx).position, Quaternion.identity, transform);
        yuyu.cake = cake;
        Debug.Log(go1.transform.GetChild(selectedIdx).position);
    }

    public void playGameMusic()
    {
        gameMusic.Play();
    }

    public void FadeOut(AudioSource a, float duration)
    {
        StartCoroutine(FadeOutCore(a, duration));
    }

    private static IEnumerator FadeOutCore(AudioSource a, float duration)
    {
        float startVolume = a.volume;

        while (a.volume > 0)
        {
            a.volume -= startVolume * Time.deltaTime / duration;
            yield return new WaitForEndOfFrame();
        }

        a.Stop();
        a.volume = startVolume;
    }
}
