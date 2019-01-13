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
            Debug.Log("Gameover");
        currentLevelController = transform.Find(levelPrefixOf(currentLevel)).GetComponent<LevelController>();
        StartTriggered();
    }
}
