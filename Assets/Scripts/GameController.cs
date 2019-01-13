using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject Levels;

    LevelController prevLevelController;
    LevelController currentLevelController;

    public bool globalWinState = false;

    public int currentLevel = 1;
    int levelCount = 1;

    // Use this for initialization
    void Start()
    {
        currentLevelController = transform.Find(levelPrefixOf(currentLevel)).GetComponent<LevelController>();
        StartTriggered();
        levelCount = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (globalWinState)
        {
            if (Input.GetMouseButtonDown(0))
                GameObject.Find("WinArt").GetComponent<Animator>().SetBool("visible", false);
        }
    }

    public String levelPrefixOf(int i)
    {
        return "Level" + i;
    }

    public void StartTriggered()
    {
        currentLevelController.started = true;
    }

    public void CompleteLevel()
    {
        currentLevel++;
        if (currentLevel > levelCount)
        {
            globalWinState = true;
            GameObject.Find("WinArt").GetComponent<Animator>().SetBool("visible", true);
            return;
        }
        currentLevelController = transform.Find(levelPrefixOf(currentLevel)).GetComponent<LevelController>();
        StartTriggered();
    }

    public void OnRetry()
    {
        currentLevelController.Reset();
        LockUnlockPlayer(false);
    }
    public static void LockUnlockPlayer(bool locked)
    {
        var go = GameObject.Find("Youmu");
        go.GetComponentInChildren<PlayerAnimation>().movementLocked = locked;
        go.GetComponentInChildren<PlayerMovement>().movementLocked = locked;
    }
}
