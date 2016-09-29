﻿using UnityEngine;
using System.Collections;


/// <summary>
/// This object is used to tell the game whose turn it is and what the game should do next
/// </summary>
public class GameFlowManager : MonoBehaviour {

    public static GameFlowManager INSTANCE;

    public int currentState = 0;
    public IGameState[] gameStates = new IGameState[5];

    void Awake()
    {
        if(INSTANCE == null)
        {
            INSTANCE = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }

        gameStates[0] = new DrawCardState();
        gameStates[1] = new PlayCardState();
        gameStates[2] = new AIPlayState();
        gameStates[3] = new UpdateDayState();
        gameStates[4] = new UpdateTerrainState();


    }

    // Use this for initialization
    void Start () {
        gameStates[currentState].Start();
    }
	
	// Update is called once per frame
	void Update () {
        gameStates[currentState].UpdateState();
        
	}

    public void NextState()
    {
        currentState++;
        currentState = currentState % gameStates.Length;
        gameStates[currentState].Start();
    }


}
