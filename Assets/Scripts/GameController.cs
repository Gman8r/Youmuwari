using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    LevelController levelController;
    // Use this for initialization
    void Start()
    {
        levelController = transform.Find(levelPrefixOf(1)).GetComponent<LevelController>();
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
        throw new NotImplementedException();
    }
}
